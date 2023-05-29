
window.addSub = addSubCategory;
window.onload = function () {
    initialize();
}

let sub1Category = {
    "Id": 0,
    "Name": "",
    "Parent": false
};
let sub2Category = {
    "Id": 0,
    "Name": "",
    "Parent": false
};
let sub3Category = {
    "Id": 0,
    "Name": "",
    "Parent": false
};

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

        x.addEventListener('click', function (e) {
            document.querySelector('#add-sub-modal').setAttribute('data-id', model.Id);
            document.querySelector('#add-sub-modal').setAttribute('data-parent', model.Parent);

            $("#add-sub-modal").modal("show");
        });
    });
}

async function getSubCategories(parentId, parent, element) {
    let result = await fetch("/category/subcategories?parentId=" + parentId + "&isParent=" + parent);
    if (!result.ok) {
        element.innerHTML = "";
        element.setAttribute('disabled', true);
        return;
    }

    let data = await result.json();
    if (data.length < 1) {
        element.innerHTML = "";
        element.setAttribute('disabled', true);
        return;
    }

    let options = "";

    data.forEach(x => {
        options += '<option value=' + x.id + '>' + x.categoryName + '</option>';
    })

    element.innerHTML = options;
    element.removeAttribute('disabled');

    let btns = element.parentNode.querySelectorAll('button');
    btns.forEach(x => {
        x.removeAttribute('disabled');
    })
}
async function addSubCategory() {
    let name = document.querySelector('#categoryName').value;
    let description = document.querySelector('#categoryDesc').value;
    let parentId = document.querySelector('#add-sub-modal').dataset['id'];
    let isParent = document.querySelector('#add-sub-modal').dataset['parent'];

    let model = {
        "CategoryName": name,
        "Description": description,
        "ParentId": parentId,
        "IsParent": isParent,
    };

    let result = await fetch('/category/subcategory/add', { method: 'POST', body: JSON.stringify(model), headers: { 'Content-Type': 'application/json' } });
    if (!result.ok)
        return;

    let response = await result.json();
    if (response.success)
        return;

    await getSubCategories(parentId, element, isParent);
}

if (document.querySelector('#main-category')) {
    document.querySelector('#main-category').addEventListener('change', function (e) {
        let categoryId = e.target.value;

        document.querySelector('#sub-1-category').innerHTML = "";
        document.querySelector('#sub-1-category').setAttribute('disabled', true);

        document.querySelector('#sub-2-category').innerHTML = "";
        document.querySelector('#sub-2-category').setAttribute('disabled', true);

        document.querySelector('#sub-3-category').innerHTML = "";
        document.querySelector('#sub-3-category').setAttribute('disabled', true);

        document.querySelector('#sub-4-category').innerHTML = "";
        document.querySelector('#sub-4-category').setAttribute('disabled', true);

        let element = document.querySelector('#sub-1-category');
        getSubCategories(categoryId, true, element);
    });
}

if (document.querySelector('#sub-1-category')) {
    document.querySelector('#sub-1-category').addEventListener('change', function (e) {
        let categoryId = e.target.value;
        let element = document.querySelector('#sub-2-category');

        document.querySelector('#sub-2-category').innerHTML = "";
        document.querySelector('#sub-2-category').setAttribute('disabled', true);

        document.querySelector('#sub-3-category').innerHTML = "";
        document.querySelector('#sub-3-category').setAttribute('disabled', true);

        document.querySelector('#sub-4-category').innerHTML = "";
        document.querySelector('#sub-4-category').setAttribute('disabled', true);

        getSubCategories(categoryId, false, element);
        sub1Category.Id = categoryId;
        sub1Category.Parent = true;
    });
}

if (document.querySelector('#sub-2-category')) {
    document.querySelector('#sub-2-category').addEventListener('change', function (e) {
        let categoryId = e.target.value;
        let element = document.querySelector('#sub-3-category');

        document.querySelector('#sub-3-category').innerHTML = "";
        document.querySelector('#sub-3-category').setAttribute('disabled', true);

        document.querySelector('#sub-4-category').innerHTML = "";
        document.querySelector('#sub-4-category').setAttribute('disabled', true);

        getSubCategories(categoryId, false, element);
        sub2Category.Id = categoryId;
        sub2Category.Parent = false;
    });
}

if (document.querySelector('#sub-3-category')) {
    document.querySelector('#sub-3-category').addEventListener('change', function (e) {
        let categoryId = e.target.value;
        let element = document.querySelector('#sub-4-category');

        document.querySelector('#sub-4-category').innerHTML = "";
        document.querySelector('#sub-4-category').setAttribute('disabled', true);

        getSubCategories(categoryId, false, element);
        sub3Category.Id = categoryId;
        sub3Category.Parent = false;
    });
}