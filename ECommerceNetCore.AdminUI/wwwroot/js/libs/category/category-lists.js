window.onload = function () {
    getList();
}

async function getList() {
    if ($('#category-list')) {
        $('#category-list').DataTable().destroy();
        $('#category-list').DataTable({
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
                "url": "/category/list",
                "type": "GET",
                "dataType": "JSON",
                "error": function (xhr, error, code) {
                    swal.fire({ type: 'error', position: 'center', title: 'Hata! Lütfen geliştiriciye başvurun.', showConfirmButton: false, timer: 2000 });
                },
                "dataSrc": function (json) {
                    return json.data.map(function (item) {
                        return {
                            "CategoryName": item.categoryName,
                            "Descriptipn": item.descriptipn,
                            "Id": item.id
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
                { "orderable": false, "data": "CategoryName" },
                { "orderable": true, "data": "Descriptipn" },
                {
                    "data": "Id", "render": function (data, type, row) { return '<a class="btn btn-sm btn-success" href="/kategori/yeni" target="_blank" data-original-title="Düzenle" title="Düzenle">Düzenle  <i class="fa fa-edit"></i>' }
                }
            ]
        });
    }

    if ($('#sub-category-list')) {
        $('#sub-category-list').DataTable().destroy();
        $('#sub-category-list').DataTable({
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
                "url": "/category/subcategory/list",
                "type": "GET",
                "dataType": "JSON",
                "error": function (xhr, error, code) {
                    swal.fire({ type: 'error', position: 'center', title: 'Hata! Lütfen geliştiriciye başvurun.', showConfirmButton: false, timer: 2000 });
                },
                "dataSrc": function (json) {
                    return json.data.map(function (item) {
                        return {
                            "CategoryName": item.categoryName,
                            "ParentCategory": item.parentCategory,
                            "Description": item.description,
                            "Id": item.id
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
                { "orderable": false, "data": "CategoryName" },
                { "orderable": true, "data": "Description" },
                { "orderable": true, "data": "ParentCategory" },
                {
                    "data": "Id", "render": function (data, type, row) { return '<a class="btn btn-sm btn-success" href="/kategori/yeni" target="_blank" data-original-title="Düzenle" title="Düzenle">Düzenle  <i class="fa fa-edit"></i>' }
                }
            ]
        });
    }
}