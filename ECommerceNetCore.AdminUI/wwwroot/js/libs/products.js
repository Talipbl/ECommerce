import { getFormJson } from '../modules/form.js'


let subCategoryId = [];
let subSelect = document.querySelector('#sub-category');
let date = new Date;
date.setDate(date.getDate() + 1);

window.onload = function () {
    initialize();
}
window.remove = removeOption;
window.checkCategory = checkMainCategory;
window.checkSubCategory = checkSubCategory;

function initialize() {
    //Select2
    $('.select2').select2({
        theme: 'bootstrap4'
    });

    $('#main-category').select2({
        theme: 'bootstrap4'
    }).on('select2:select', function (e) {
        checkCategory(e);
    });

    $('select[name="SubCategoryId"]').select2({
        theme: 'bootstrap4'
    }).on('select2:select', function (e) {
        checkSubCategory(e);
    });

    //Summernote
    $('#description').summernote({
        height: 350
    });

    //Date and time picker
    $('#discountdatetime').datetimepicker({
        format: 'DD/MM/YYYY HH:mm',
        icons: { time: 'far fa-clock' },
        minDate: new Date($.now()),
        defaultDate: date,
    });

    $('#availabledatetime').datetimepicker({
        format: 'DD/MM/YYYY HH:mm',
        icons: { time: 'far fa-clock' },
        minDate: new Date($.now()),
        defaultDate: date,
    });
}
function removeOption(card) {
    let parentEelement = card.parentNode.parentNode.parentNode.parentNode.parentNode;
    parentEelement.remove();
}
function removeSubCategory() {
    delete subCategoryId[subCategoryId.length - 1];
    subSelect.parentNode.parentNode.remove();
    let selects = document.querySelectorAll('[name="SubCategoryId"]');
    subSelect = selects[selects.length - 1];
    if (selects.length == 1) {
        document.querySelector('#btn-remove-category').setAttribute('hidden', true);
        document.querySelector('#btn-add-category').removeAttribute('disabled');
    }
}
function checkSubCategory(e) {
    if (e.target.id == "sub-category") {
        document.querySelector('#sub-categories').innerHTML = "";
        subSelect = document.querySelector('#sub-category');
        subCategoryId = [];
    }
    if (e.target.value != '0') {
        document.querySelector('#btn-add-category').removeAttribute('disabled');
    }
    else {
        document.querySelector('#btn-add-category').setAttribute('disabled', true);
    }
}

async function addProduct() {

    $('#collapseErrors').collapse('hide');

    let answer = await swal.fire({ title: 'İşlemi tamamlamak istediğinize emin misiniz?', icon: 'question', confirmButtonColor: '#3085d6', cancelButtonColor: '#d33', showCancelButton: true, confirmButtonText: 'Evet', cancelButtonText: 'Hayır' });
    if (!answer.value) {
        return;
    }

    swal.fire({
        title: "İşleniyor...", text: "Lütfen bekleyiniz...", allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => {
            swal.showLoading();
        }
    });

    const productForm = document.querySelector('#product-form');
    const CategoryForm = document.querySelector('#category-form');
    const OptionForm = document.querySelectorAll('#option-form');

    let product = getFormJson(productForm);
    let category = getFormJson(CategoryForm);

    delete product["files"];

    let options = [];
    OptionForm.forEach(form => {
        let opt = getFormJson(form);
        opt["IsSale"] = opt["IsSale"][0];
        opt["IsAvailable"] = opt["IsAvailable"][0];
        options.push(opt);
    });

    Object.assign(product, category);
    product["ProductOptions"] = options;

    const jsonData = JSON.stringify(product);

    let result = await fetch("/products/add", { method: 'POST', body: jsonData, headers: { 'Content-Type': 'application/json' } });
    let jsonResult = await result.json();
    if (!jsonResult.success) {
        let errors = "";
        jsonResult.data.forEach(error => {
            errors += '<li>' + error.errorMessage + '</li>';
        });
        document.querySelector('#errors').innerHTML = '<ul><h5 class="text-danger">Ürün bilgilerinde hata var. Lütfen kontrol edip tekrar deneyiniz.</h5>' + errors + '</ul>';
        $('#collapseErrors').collapse('show');
        swal.close();
        return;
    }
    $('#collapseErrors').collapse('hide');
    await swal.fire({ type: 'success', position: 'center', title: json.Message, showConfirmButton: false, timer: 1500 });
    location.reload();
}
async function addOption() {
    let options = document.querySelector('#options-section');
    let result = await fetch("/products/option/partial");
    let htmlData = await result.json();

    let div = document.createElement('div');
    div.innerHTML = htmlData;
    options.appendChild(div);
}
async function addSubCategory() {
    subCategoryId.push(subSelect.value);
    let lastIndex = subCategoryId[subCategoryId.length - 1];
    let subcategories = document.querySelector('#sub-categories');
    let result = await fetch("/products/subcategory/partial?parentId=" + lastIndex);
    let htmlData = await result.json();

    let div = document.createElement('div');
    div.innerHTML = htmlData;
    subcategories.appendChild(div);

    let selects = subcategories.querySelectorAll('.select2');
    subSelect = selects[selects.length - 1];

    $(subSelect).select2({
        theme: 'bootstrap4'
    });

    $(subSelect).select2({
        theme: 'bootstrap4'
    }).on('select2:select', function (e) {
        checkSubCategory(e);
    });

    document.querySelector('#btn-add-category').setAttribute('disabled', true);
    document.querySelector('#btn-remove-category').removeAttribute('hidden');
}
async function checkMainCategory(e) {

    let parentId = e.target.value;
    let subSelect = document.querySelector('#sub-category');

    if (parentId != '0') {
        var result = await fetch("/category/subcategories?parentId=" + parentId + "&isParent=" + true);
        var categories = await result.json();

        subSelect.innerHTML = '<option value="0" selected>Seçiniz</option>';
        categories.forEach(item => {
            subSelect.innerHTML += '<option value="' + item.id + '">' + item.categoryName + '</option>'
        });

        subSelect.removeAttribute('disabled');
    }
    else {
        document.querySelector('#sub-category').setAttribute('disabled', true);
    }
    document.querySelector('#sub-categories').innerHTML = "";
    subSelect = document.querySelector('#sub-category');
    subCategoryId = [];
}

document.querySelector('#btn-complete').addEventListener('click', function () {
    addProduct();
});
document.querySelector('#btn-add-option').addEventListener('click', function () {
    addOption();
});
document.querySelector('#btn-add-category').addEventListener('click', function () {
    addSubCategory();
});
document.querySelector('#btn-remove-category').addEventListener('click', function () {
    removeSubCategory();
});