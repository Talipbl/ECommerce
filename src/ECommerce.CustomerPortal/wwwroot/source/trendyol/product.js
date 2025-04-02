import { initCopyToClipboard, checkDisabled, makeDecision, initSelectAllCheckbox } from '/source/utils.js';

window.onload = function () {
    getList();
}

async function getList() {
    $('#products').DataTable().destroy();
    $('#products').DataTable({
        language: {
            lengthMenu: "Her sayfada _MENU_ öğe göster",
            info: "_TOTAL_ kayıttan _START_ - _END_ arası gösteriliyor",
            paginate: {
                next: "Sonraki",
                previous: "Önceki",
            },
        },
        "paging": true,
        "lengthChange": true,
        "searching": false,
        "ordering": true,
        "info": true,
        "responsive": true,
        "serverSide": true,
        "autoWidth": false,
        "stateSave": true,
        "pageLength": 25,
        "lengthMenu": [10, 25, 50, 100],
        "ajax": {
            "beforeSend": function () {
                swal.fire({ text: 'Liste yükleniyor...', allowOutsideClick: false, allowEscapeKey: false });
            },
            "complete": function () {
                swal.close()
            },
            "url": "/trendyol/product/getProducts",
            "type": "POST",
            "dataType": "JSON",
            "contentType": "application/json",
            "processData": false,
            "error": function (xhr, error, code) {
                swal.fire({ icon: 'error', position: 'center', title: 'Hata!', text: 'Lütfen geliştiriciye başvurun.', showConfirmButton: false, timer: 2000 });
            },
            "dataSrc": function (json) {
                return json.data.map(function (item) {
                    return {
                        "ProductId": item.productMainId,
                        "Barcode": item.barcode,
                        "Brand": item.brand,
                        "CategoryName": item.categoryName,
                        "Description": item.description,
                        "HasActiveCampaign": item.hasActiveCampaign,
                        "ImageUrl": item.imageUrl,
                        "ListPrice": item.listPrice,
                        "ProductCode": item.productCode,
                        "ProductContentId": item.productContentId,
                        "Quantity": item.quantity,
                        "SalePrice": item.salePrice,
                        "StockCode": item.stockCode,
                        "SupplierId": item.supplierId,
                        "Title": item.title,
                        "Rejected": item.rejected,
                        "DeliveryDuration": item.deliveryDuration,
                        "Status": item.status,
                        "OnSale": item.onSale
                    }
                });
            },
            "data": function (d) {
                return JSON.stringify({
                    draw: d.draw,
                    start: d.start,
                    length: d.length,
                    order: d.order[0],
                    columnName: d.columns[d.order[0].column].data,
                    direction: d.order[0].dir
                });
            },
        },
        "columns": [
            {
                "orderable": false, "data": "ProductId", "render": function (data, type, row) {
                    return '<div class="form-check form-check-success"><label class="form-check-label"><input ' + checkDisabled(row.OnSale) + ' data-id=' + data + ' type="checkbox" class="form-check-input item"><i class="input-helper"></i></label></div>';
                }
            },
            {
                "orderable": false, "data": "Barcode", "render": function (data, type, row) {
                    return '<label class="form-label"><b>' + row.Barcode + '</b><i class="fa fa-copy copy2clip m-1" data-copy=' + data + '></i></label></div>';
                }
            },
            {
                "orderable": false, "data": "Title", "render": function (data, type, row) {
                    return '<label class="form-label">' + data.substringByLength(50, true) + '</label><div class="list"><ul><li class="list-item"><small>Model Kodu:</small><small><b>' + row.ProductCode + '</b><i class="fa fa-copy copy2clip m-1" data-copy=' + row.ProductCode + '></i></small></li><li class="list-item"><small>Stok Kodu:</small><small><b>' + row.StockCode + '</b><i class="fa fa-copy copy2clip m-1" data-copy=' + row.StockCode + '></i></small></li></ul></div>';
                }
            },
            { "orderable": false, "data": "Status" },
            {
                "orderable": false, "data": "SalePrice", "render": function (data, type, row) {
                    return '<div class="input-group" style="width:150px"><div class="input-group-prepend"><span class="input-group-text bg-' + makeDecision(row.OnSale, "success", "danger") + ' text-white">₺</span></div><input type="number" class="form-control" value="' + data + '" ' + checkDisabled(row.OnSale) + '></div>';
                }
            },
            {
                "orderable": false, "data": "Quantity", "render": function (data, type, row) {
                    return '<div class="input-group" style="width:75px"><input type="number" class="form-control" value="' + data + '" ' + checkDisabled(row.OnSale) + '></div>';
                }
            },
            {
                "orderable": false, "data": "ListPrice", "render": function (data, type, row) {
                    return '<div class="input-group" style="width:150px"><div class="input-group-prepend"><span class="input-group-text bg-' + makeDecision(row.OnSale, "success", "danger") + ' text-white">₺</span></div><input type="number" class="form-control" value="' + data + '" disabled></div>';
                } },
            {
                "orderable": false, "data": "DeliveryDuration", "render": function (data, type, row) {
                    return '<div class="input-group" style="width:75px"><input type="number" class="form-control" value="' + data + '" ' + checkDisabled(row.OnSale) + '></div>';
                } },
            { "orderable": false, "data": "Brand" },
            { "orderable": false, "data": "CategoryName" },
            {
                "orderable": false, "data": "ProductId", "render": function (data, type, row) {
                    return '<a href="/trendyol/product/detail/' + row.Barcode + '" target="_blank"><button type="button" class="btn btn-social-icon btn-outline-facebook"><i class="fa fa-info"></i></button></a><button type="button" class="btn btn-social-icon btn-outline-youtube"><i class="ti-youtube"></i></button><button type="button" class="btn btn-social-icon btn-outline-twitter"><i class="ti-twitter-alt"></i></button>';
                }
            }
        ],
        "drawCallback": function (settings) {
            initCopyToClipboard();
            initSelectAllCheckbox(document);
        }
    });
}