
window.onload = function () {
    getList();
}

async function getList() {
    $('#products').DataTable().destroy();
    $('#products').DataTable({
        "oLanguage": {
            "lengthMenu": "Gösterim: _MENU_"
        },
        "paging": true,
        "lengthChange": true,
        "searching": false,
        "ordering": true,
        "info": true,
        "responsive": true,
        "serverSide": true,
        "autoWidth": true,
        "stateSave": true,
        "lengthMenu": [25, 50, 100],
        "ajax": {
            "beforeSend": function () {
                swal.fire({ title: 'Liste yükleniyor...', allowOutsideClick: false, allowEscapeKey: false });
            },
            "complete": function () {
                swal.close()
            },
            "url": "/trendyol/getProducts",
            "type": "POST",
            "dataType": "JSON",
            "contentType": "application/json",
            "processData": false,
            "error": function (xhr, error, code) {
                swal.fire({ icon: 'error', position: 'center', title: 'Hata! Lütfen geliştiriciye başvurun.', showConfirmButton: false, timer: 2000 });
            },
            "dataSrc": function (json) {
                return json.data.map(function (item) {
                    return {
                        "Id": item.id,
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
                        "StockUnitType": item.stockUnitType,
                        "SupplierId": item.supplierId,
                        "Title": item.title,
                        "Rejected": item.rejected,
                        "DeliveryDuration": item.deliveryDuration
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
            { "orderable": false, "data": "Id" },
            { "orderable": false, "data": "ProductId"},
            { "orderable": false, "data": "Barcode" },
            { "orderable": false, "data": "Brand" },
            { "orderable": false, "data": "CategoryName" },
            { "orderable": false, "data": "Title" },
            { "orderable": false, "data": "Description" },
            { "orderable": false, "data": "ImageUrl" },
            { "orderable": false, "data": "SalePrice" },
            { "orderable": false, "data": "ListPrice" }
        ]
    });
}