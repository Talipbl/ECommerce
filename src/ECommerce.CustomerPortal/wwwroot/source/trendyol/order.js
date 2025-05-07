import { initCopyToClipboard, checkDisabled, makeDecision, initSelectAllCheckbox } from '/source/utils.js';

window.onload = function () {
    getList();
}

async function getList() {
    $('#orders').DataTable().destroy();
    $('#orders').DataTable({
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
            "url": "/trendyol/order/getOrders",
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
                        "Id": item.Id,
                        "OrderNumber": item.orderNumber,
                        "OrderDate": item.orderDate,
                        "TotalPrice": item.totalPrice,
                        "FirstName": item.customerFirstName,
                        "LastName": item.customerLastName,
                        "Status": item.status,
                        "CargoProviderName": item.cargoProviderName
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
                "orderable": false, "data": "Id", "render": function (data, type, row) {
                    return '<div class="form-check form-check-success"><label class="form-check-label"><input ' + checkDisabled(true) + ' data-id=' + data + ' type="checkbox" class="form-check-input item"><i class="input-helper"></i></label></div>';
                }
            },
            {
                "orderable": false, "data": "OrderNumber", "render": function (data, type, row) {
                    return '<label class="form-label"><b>' + data + '</b><i class="fa fa-copy copy2clip m-1" data-copy=' + data + '></i></label></div>';
                }
            },
            { "orderable": false, "data": "FirstName" },
            { "orderable": false, "data": "LastName" },
            { "orderable": false, "data": "TotalPrice" },
            { "orderable": false, "data": "Status" },
            { "orderable": false, "data": "CargoProviderName" },
            {
                "orderable": false, "data": "Id", "render": function (data, type, row) {
                    return '<a href="/trendyol/order/detail/' + row.Id + '" target="_blank"><button type="button" class="btn btn-social-icon btn-outline-facebook"><i class="fa fa-info"></i></button></a><button type="button" class="btn btn-social-icon btn-outline-youtube"><i class="ti-youtube"></i></button><button type="button" class="btn btn-social-icon btn-outline-twitter"><i class="ti-twitter-alt"></i></button>';
                }
            }
        ],
        "drawCallback": function (settings) {
            initCopyToClipboard();
            initSelectAllCheckbox(document);
        }
    });
}