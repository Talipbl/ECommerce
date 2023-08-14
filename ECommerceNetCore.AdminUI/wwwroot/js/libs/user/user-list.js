import { getStatus } from '../../modules/utilities.js';

window.onload = function () {
    getList();
}

async function getList() {
    $('#user-list').DataTable().destroy();
    $('#user-list').DataTable({
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
                swal.fire({ title: 'Liste yükleniyor...', allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, onOpen: () => { swal.showLoading(); } });
            },
            "complete": function () {
                swal.close()
            },
            "url": "/users/list",
            "type": "GET",
            "dataType": "JSON",
            "error": function (xhr, error, code) {
                swal.fire({ type: 'error', position: 'center', title: 'Hata! Lütfen geliştiriciye başvurun.', showConfirmButton: false, timer: 2000 });
            },
            "dataSrc": function (json) {
                return json.data.map(function (item) {
                    return {
                        "Id": item.id,
                        "Name": item.firstName + " " + item.lastName,
                        "MailAddress": item.mailAddress,
                        "Identity": item.identity,
                        "MobilePhoneNumber": item.mobilePhoneNumber,
                        "Country": item.country,
                        "Status": item.statusId
                    }
                });
            },
            "data": function (d) {
                d.draw = d.draw;
                d.start = d.start;
                d.length = d.length;
                d.order = d.order[0];
                d.columnName = d.columns[d.order.column].data;
                d.direction = d.order.dir;
            },
        },
        "columns": [
            { "orderable": false, "data": "Identity", "render": function (data, type, row) { return '<b>' + data + '</b>'; } },
            { "orderable": false, "data": "Name" },
            { "orderable": true, "data": "MailAddress" },
            { "orderable": true, "data": "MobilePhoneNumber" },
            { "orderable": true, "data": "Country" },
            { "orderable": false, "data": "Status", "render": function (data, type, row) { return getStatus(data) } },
            {
                "data": "Id",
                "render": function (data, type, row) {
                    let render = '';
                    render += '<div class="input-group-prepend">';
                    render += '<button type="button" class="btn btn-sm btn-dark dropdown-toggle" data-toggle="dropdown" aria-expanded="false">İşlemler</button>';
                    render += '<ul class="dropdown-menu" style="">' +
                        '<li class="dropdown-item"><a href="/urunler/duzenle/' + row.Id + '" target="_blank" data-original-title="Düzenle" title="Düzenle"><i class="fa fa-edit"></i> Düzenle</a>&nbsp;</li>' +
                        '<li class="dropdown-item"><a href="javascript:;" data-original-title="Liste Dışı Bırak" title="Hesabı Pasifleştir"><i class="fa fa-ban"></i> Hesabı Pasifleştir</a>&nbsp;</li>' +
                        '<li class="dropdown-item"><a href="javascript:;" data-original-title="Sil" title="Sil"><i class="fa fa-times"></i> Sil (Önerilmez)</a></li>' +
                        '<li class="dropdown-divider"></li></ul>';
                    render += "</div>";
                    return render;
                }
            }
        ]
    });
}