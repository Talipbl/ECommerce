import { getFormJson } from '../modules/form.js'

let subCategoryId = [];
let subSelect = document.querySelector('#sub-category');

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
}
function addProduct() {

    const productForm = document.querySelector('#product-form');
    const CategoryForm = document.querySelector('#category-form');
    const OptionForm = document.querySelectorAll('#option-form');

    let product = getFormJson(productForm);
    let category = getFormJson(CategoryForm);
    let option = [];

    OptionForm.forEach(form => {
        option.push(getFormJson(form));
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

async function addOption() {
    let options = document.querySelector('#options-section');
    let result = await fetch("/products/option/partial");
    let htmlData = await result.json();

    options.innerHTML += htmlData;
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