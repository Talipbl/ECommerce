import { isNullOrEmpty } from '../../modules/utilities.js';

window.onload = function () {
    initialize();
}
window.search = search;
window.bulkAddTy = bulkAddToTrendyol;

function initialize() {
    $(document).on('click', '[data-toggle="lightbox"]', function (event) {
        event.preventDefault();
        $(this).ekkoLightbox({
            alwaysShowClose: true
        });
    });
}

async function search(pg) {
    let url = document.querySelector('#search-url').value;
    if (isNullOrEmpty(url)) {
        return;
    }

    swal.fire({
        title: "Aranıyor...", text: "Lütfen bekleyiniz...", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => {
            swal.showLoading();
        }
    });

    let response = await fetch("/trendyol/crawler/search", { method: 'POST', body: JSON.stringify({ 'Url': url, 'Page': pg }), headers: { 'Content-Type': 'application/json' } });
    let jsonResult = await response.json();

    document.querySelector('#products').innerHTML = jsonResult;

    let paginations = document.querySelectorAll('.pagination');
    paginations.forEach(pagination => {
        let pages = pagination.querySelectorAll('a');
        pages.forEach(btn => {
            btn.addEventListener('click', function (e) {
                let page = e.target.getAttribute('page');
                search(page);
            });
        });
    });

    let btnsTrendyol = document.querySelectorAll('.trendyol');
    btnsTrendyol.forEach(btn => {
        btn.addEventListener('click', function (e) {
            let id = e.target.getAttribute('product-id');
            addToTrendyol(id);
        });
    });

    swal.close();
}

async function addToTrendyol(id) {
    let ids = [id];
    let response = await fetch("/trendyol/crawler/add/trendyol", { method: 'POST', body: JSON.stringify(ids), headers: { 'Content-Type': 'application/json' } });
    let jsonResult = await response.json();

    if (!jsonResult.success) {
        let errors = '';
        jsonResult.data.forEach(msg => {
            errors += ' ' + msg.message
        });

        toastr.error(errors);
    }

    toastr.success('Başarıyla gönderildi.');
}

async function bulkAddToTrendyol() {

    let chcks = document.querySelectorAll('input[type="checkbox"]');
    let ids = [];
    chcks.forEach(input => {
        if (input.checked) {
            ids.push(input.id);
        }
    });

    if (ids.length < 1)
        return await swal.fire({ icon: 'success', position: 'center', title: 'En az 1 ürün seçmelisiniz.', showConfirmButton: false, timer: 1500 });

    swal.fire({
        title: "İşleniyor", text: "Lütfen bekleyiniz...", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => {
            swal.showLoading();
        }
    });

    let response = await fetch("/trendyol/crawler/add/trendyol", { method: 'POST', body: JSON.stringify(ids), headers: { 'Content-Type': 'application/json' } });
    let jsonResult = await response.json();

    if (!jsonResult.success) {
        let errors = '';
        jsonResult.data.forEach(msg => {
            errors += ' ' + msg.message
        });

        return swal.fire({ icon: 'error', position: 'center', title: errors, showConfirmButton: false, timer: 1500 });
    }

    await swal.fire({ icon: 'success', position: 'center', title: jsonResult.message, showConfirmButton: false, timer: 1500 });
}