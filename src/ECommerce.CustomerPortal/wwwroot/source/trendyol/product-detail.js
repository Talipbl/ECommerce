
window.update = updateProduct;
window.remove = removeImage;

$(document).ready(function () {
    $('#categoryName').select2({
        allowClear: true,
        minimumInputLength: 3,
        ajax: {
            url: function (params) {
                var search = params.term;
                return '/trendyol/product/getCategories/' + search;
            },
            type: 'GET',
            dataType: 'json',
            data: function (params) {
                return {}; // Gereksiz query parametrelerini kaldırıyoruz.
            },
            processResults: function (data) {
                return {
                    results: data.data.map(item => ({ id: item.id, text: item.name }))
                };
            }
        }
    });
});

function updateProduct() {
    var formData = $('#updateProductForm').serializeArray();
    var jsonData = {};

    // Form verilerini JSON formatına çeviriyoruz
    $.each(formData, function () {
        jsonData[this.name] = this.value;
    });

    var selectedCategoryId = $('#categoryName').val();
    jsonData["CategoryId"] = selectedCategoryId; 

    // Resimleri JSON'a ekliyoruz
    jsonData["Images"] = [];
    $('#imageContainer img').each(function () {
        jsonData["Images"].push($(this).attr('src'));
    });

    $.ajax({
        url: '/trendyol/product/update',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(jsonData),
        success: function (response) {
            alert('Ürün başarıyla güncellendi!');
        },
        error: function (error) {
            alert('Hata oluştu: ' + error.responseText);
        }
    });
}

function removeImage(button, imageUrl) {
    $(button).parent().remove();
}