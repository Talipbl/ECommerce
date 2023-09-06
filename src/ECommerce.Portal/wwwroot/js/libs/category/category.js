import { isNullOrEmpty, addEventListenerToElement } from '../../modules/utilities.js';

window.add = addAction;
window.update = updateAction;
window.onload = function () {
    initialize();
}

let mainCategory = {
    "Id": 0,
    "Name": "",
    "Description": "",
};
let sub1Category = {
    "Id": 0,
    "Name": "",
    "Description" : "",
    "Parent": false
};
let sub2Category = {
    "Id": 0,
    "Name": "",
    "Description": "",
    "Parent": false
};
let sub3Category = {
    "Id": 0,
    "Name": "",
    "Description": "",
    "Parent": false
};
let sub4Category = {
    "Id": 0,
    "Name": "",
    "Description": "",
    "Parent": false
};
let button;

function initialize() {
    let selects = document.querySelectorAll('select');
    selects.forEach(x => {
        x.addEventListener('click', function (e) {
            let allbtns = document.querySelectorAll('.content-wrapper button');
            allbtns.forEach(z => {
                z.setAttribute('hidden', true);
            });

            let btns = e.target.parentNode.parentNode.querySelectorAll('button');
            btns.forEach(y => {
                y.removeAttribute('hidden');
            });
        });
    });

    let addSubBtns = document.querySelectorAll('.add-sub');
    addSubBtns.forEach(x => {
        x.addEventListener('click', function (e) {
            let model = {};
            if (x.classList.contains('sub-1-btn')) {
                model = { "Id": document.querySelector('#main-category').value, "Parent": true };
            }
            else if (x.classList.contains('sub-2-btn')) {
                model = sub1Category;
            }
            else if (x.classList.contains('sub-3-btn')) {
                model = sub2Category;
            }
            else if (x.classList.contains('sub-4-btn')) {
                model = sub3Category;
            }

            document.querySelector('#add-sub-modal').setAttribute('data-id', model.Id);
            document.querySelector('#add-sub-modal').setAttribute('data-parent', model.Parent);
            button = e.target;

            $("#add-sub-modal").modal("show");
        });
    });

    let editSubBtns = document.querySelectorAll('.edit-sub');
    editSubBtns.forEach(x => {
        x.addEventListener('click', function (e) {
            let model = {};
            if (x.classList.contains('sub-1-btn')) {
                model = sub1Category;
            }
            else if (x.classList.contains('sub-2-btn')) {
                model = sub2Category;
            }
            else if (x.classList.contains('sub-3-btn')) {
                model = sub3Category;
            }
            else if (x.classList.contains('sub-4-btn')) {
                model = sub4Category;
            }

            if (!model.Name) {
                return;
            }

            document.querySelector('#update-form #categoryName').value = model.Name;
            document.querySelector('#update-form #categoryDesc').innerHTML = !model.Description ? "" : model.Description;

            document.querySelector('#modify-sub-modal').setAttribute('data-id', model.Id);
            document.querySelector('#modify-sub-modal').setAttribute('data-type', "sub");

            $("#modify-sub-modal").modal("show");
        });
    });

    //Form Validation - çalışmıyor
    $('#quickForm').validate({
        rules: {
            name: {
                required: true,
                length: 3,
            },
            desc: {
                required: true,
                length: 10,
            }
        },
        messages: {
            name: {
                required: "Geçerli bir ad girin.",
                length: "En az 3 karakter giriniz."
            },
            desc: {
                required: "Geçerli bir ad girin.",
                length: "En az 10 karakter giriniz."
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
}

async function addAction() {
    let name = document.querySelector('#category-form #categoryName').value;
    let description = document.querySelector('#category-form #categoryDesc').innerHTML;

    if (isNullOrEmpty(name) || name.length < 3) {
        return;
    }

    let id = document.querySelector('#add-sub-modal').dataset['id'];
    if (id == 0) {
        await addCategory(name, description);
    }
    else {
        await addSubCategory(name, description);
    }
}
async function updateAction() {
    let name = document.querySelector('#update-form #categoryName').value;
    let description = document.querySelector('#update-form #categoryDesc').value;

    if (isNullOrEmpty(name) || name.length < 3) {
        return;
    }

    let id = document.querySelector('#modify-sub-modal').dataset['id'];
    let type = document.querySelector('#modify-sub-modal').dataset['type'];
    if (type === "sub") {
        updateSubCategory(id, name, description);
    }
    else {
        updateCategory(id, name, description);
    }
}
async function getSubCategories(parentId, parent, element) {
    let result = await fetch("/category/subcategories?parentId=" + parentId + "&isParent=" + parent);
    if (!result.ok) {
        element.innerHTML = "";
        element.removeAttribute('disabled');
        return;
    }

    let data = await result.json();
    if (data.length < 1) {
        element.innerHTML = "";
        element.removeAttribute('disabled');
        return;
    }

    let options = "";

    data.forEach(x => {
        options += '<option value=' + x.id + ' data-desc="' + x.description + '">' + x.categoryName + '</option>';
    })

    element.innerHTML = options;
    element.removeAttribute('disabled');

    let btns = element.parentNode.querySelectorAll('button');
    btns.forEach(x => {
        x.removeAttribute('disabled');
    })
}
async function addSubCategory(name, description) {
    swal.fire({ allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => { swal.showLoading(); } });

    let parentId = document.querySelector('#add-sub-modal').dataset['id'];
    let isParent = document.querySelector('#add-sub-modal').dataset['parent'];

    let model = {
        "CategoryName": name,
        "Description": description,
        "ParentId": parseInt(parentId),
        "IsParent": isParent.toLowerCase() === 'true',
    };

    let result = await fetch('/category/subcategory/add', { method: 'POST', body: JSON.stringify(model), headers: { 'Content-Type': 'application/json' } });
    if (!result.ok)
        return;

    let response = await result.json();
    if (response.success)
        return;

    let element = button.parentNode.parentNode.parentNode.querySelector('select');
    swal.close();
    $("#add-sub-modal").modal("hide");
    await getSubCategories(parentId, isParent, element);
}
async function addCategory(name, description) {
    swal.fire({ allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => { swal.showLoading(); } });

    let model = {
        "CategoryName": name,
        "Description": description,
    };

    let result = await fetch('/category/maincategory/add', { method: 'POST', body: JSON.stringify(model), headers: { 'Content-Type': 'application/json' } });
    if (!result.ok)
        return;

    let response = await result.json();
    if (response.success)
        return;

    window.location.reload();
}
async function updateSubCategory(id, name, description) {
    swal.fire({ allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => { swal.showLoading(); } });

    let model = {
        "Id": id,
        "CategoryName": name,
        "Description": description,
    };

    let result = await fetch('/category/subcategory/update', { method: 'POST', body: JSON.stringify(model), headers: { 'Content-Type': 'application/json' } });
    if (!result.ok)
        return;

    let response = await result.json();
    if (!response.success)
        return;

    window.location.reload();
}
async function updateCategory(id, name, description) {
    swal.fire({ allowOutsideClick: false, allowEscapeKey: false, allowEnterKey: false, didOpen: () => { swal.showLoading(); } });

    let model = {
        "Id": id,
        "CategoryName": name,
        "Description": description,
    };

    let result = await fetch('/category/maincategory/update', { method: 'POST', body: JSON.stringify(model), headers: { 'Content-Type': 'application/json' } });
    if (!result.ok)
        return;

    let response = await result.json();
    if (!response.success)
        return;

    window.location.reload();
}

addEventListenerToElement('#main-category', 'change', function (e) {
    let categoryId = e.target.value;

    document.querySelector('#sub-1-category').innerHTML = "";
    document.querySelector('#sub-1-category').removeAttribute('disabled');

    document.querySelector('#sub-2-category').innerHTML = "";
    document.querySelector('#sub-2-category').setAttribute('disabled', true);

    document.querySelector('#sub-3-category').innerHTML = "";
    document.querySelector('#sub-3-category').setAttribute('disabled', true);

    document.querySelector('#sub-4-category').innerHTML = "";
    document.querySelector('#sub-4-category').setAttribute('disabled', true);

    let element = document.querySelector('#sub-1-category');
    mainCategory.Id = categoryId;
    mainCategory.Name = e.target.selectedOptions[0].innerHTML;
    mainCategory.Description = e.target.selectedOptions[0].dataset['desc'];
    getSubCategories(categoryId, true, element);
    $('#collapse-edit').collapse('hide');
});

addEventListenerToElement('#sub-1-category', 'change', function (e) {
    let categoryId = e.target.value;
    let element = document.querySelector('#sub-2-category');

    document.querySelector('#sub-2-category').innerHTML = "";
    document.querySelector('#sub-2-category').removeAttribute('disabled');

    document.querySelector('#sub-3-category').innerHTML = "";
    document.querySelector('#sub-3-category').setAttribute('disabled', true);

    document.querySelector('#sub-4-category').innerHTML = "";
    document.querySelector('#sub-4-category').setAttribute('disabled', true);

    getSubCategories(categoryId, false, element);
    sub1Category.Id = categoryId;
    sub1Category.Name = e.target.selectedOptions[0].innerHTML;
    sub1Category.Description = e.target.selectedOptions[0].dataset['desc'];
    sub1Category.Parent = false;
    $('#collapse-edit').collapse('hide');
});

addEventListenerToElement('#sub-2-category', 'change', function (e) {
    let categoryId = e.target.value;
    let element = document.querySelector('#sub-3-category');

    document.querySelector('#sub-3-category').innerHTML = "";
    document.querySelector('#sub-3-category').removeAttribute('disabled');

    document.querySelector('#sub-4-category').innerHTML = "";
    document.querySelector('#sub-4-category').setAttribute('disabled', true);

    getSubCategories(categoryId, false, element);
    sub2Category.Id = categoryId;
    sub2Category.Name = e.target.selectedOptions[0].innerHTML;
    sub2Category.Description = e.target.selectedOptions[0].dataset['desc'];
    sub2Category.Parent = false;
    $('#collapse-edit').collapse('hide');
});

addEventListenerToElement('#sub-3-category', 'change', function (e) {
    let categoryId = e.target.value;
    let element = document.querySelector('#sub-4-category');

    document.querySelector('#sub-4-category').innerHTML = "";
    document.querySelector('#sub-4-category').removeAttribute('disabled');

    getSubCategories(categoryId, false, element);
    sub3Category.Id = categoryId;
    sub3Category.Name = e.target.selectedOptions[0].innerHTML;
    sub3Category.Description = e.target.selectedOptions[0].dataset['desc'];
    sub3Category.Parent = false;
    $('#collapse-edit').collapse('hide');
});

addEventListenerToElement('#sub-4-category', 'change', function (e) {
    let categoryId = e.target.value;

    sub4Category.Id = categoryId;
    sub4Category.Name = e.target.selectedOptions[0].innerHTML;
    sub4Category.Description = e.target.selectedOptions[0].dataset['desc'];
    sub4Category.Parent = false;
    $('#collapse-edit').collapse('hide');
});

addEventListenerToElement('#sub-1', 'change', function (e) {
    let categoryId = e.target.value;
    let element = document.querySelector('#sub-2');

    document.querySelector('#sub-2').innerHTML = "";
    document.querySelector('#sub-2').removeAttribute('disabled');

    document.querySelector('#sub-3').innerHTML = "";
    document.querySelector('#sub-3').setAttribute('disabled', true);

    document.querySelector('#sub-4').innerHTML = "";
    document.querySelector('#sub-4').setAttribute('disabled', true);

    getSubCategories(categoryId, false, element);
    sub1Category.Id = categoryId;
    sub1Category.Parent = false;
});

if (document.querySelector('#sub-2')) {
    document.querySelector('#sub-2').addEventListener('change', function (e) {
        let categoryId = e.target.value;
        let element = document.querySelector('#sub-3');

        document.querySelector('#sub-3').innerHTML = "";
        document.querySelector('#sub-3').removeAttribute('disabled');

        document.querySelector('#sub-4').innerHTML = "";
        document.querySelector('#sub-4').setAttribute('disabled', true);

        getSubCategories(categoryId, false, element);
        sub2Category.Id = categoryId;
        sub2Category.Parent = false;
    });
}

if (document.querySelector('#sub-3')) {
    document.querySelector('#sub-3').addEventListener('change', function (e) {
        let categoryId = e.target.value;
        let element = document.querySelector('#sub-4');

        document.querySelector('#sub-4').innerHTML = "";
        document.querySelector('#sub-4').removeAttribute('disabled');

        getSubCategories(categoryId, false, element);
        sub3Category.Id = categoryId;
        sub3Category.Parent = false;
    });
}

if (document.querySelector('.add-main')) {
    document.querySelector('.add-main').addEventListener('click', function (e) {
        document.querySelector('#add-sub-modal').setAttribute('data-id', 0);
        $("#add-sub-modal").modal("show");
    });
}

if (document.querySelector('.edit-main')) {
    document.querySelector('.edit-main').addEventListener('click', function (e) {
        document.querySelector('#update-form #categoryName').value = mainCategory.Name;
        document.querySelector('#update-form #categoryDesc').value = mainCategory.Description;

        document.querySelector('#modify-sub-modal').setAttribute('data-id', mainCategory.Id);
        document.querySelector('#modify-sub-modal').setAttribute('data-type', "main");

        $("#modify-sub-modal").modal("show");
    });
}

document.querySelector('#category-form').addEventListener('keyup', function (e) {
    if (e.keyCode == 13) {
        action();
    }
})