$(function () {
    var accessToken = "123abc"; //access token

    $("#search-products-submit").on("click", function () {
        var url = "/api/products/filters/";
        var parent = $("#search-products");
        var resultDiv = $("#search-products-result");
        var model = parent.find("[name=Model]").val();
        var brand = parent.find("[name=Brand]").val();
        var desc = parent.find("[name=Description]").val();

        url += model + "/" + brand + "/" + desc;

        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            contentType: "application/json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + accessToken);
            },
        }).done(function (data) {
            console.log(data);
            if (data.length > 0) {
                resultDiv.html(JSON.stringify(data));
            }
            else {
                resultDiv.html("No product found");
            }
        }).fail(function (data) {
            resultDiv.html(data);
        });
    });

    $("#search-by-id-submit").on("click", function () {
        var url = "/api/products/";
        var parent = $("#search-by-id");
        var resultDiv = $("#search-by-id-result");
        var id = parent.find("[name=Id]").val();
        url += id;

        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            contentType: "application/json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + accessToken);
            },
        }).done(function (data) {
            console.log(data);
            resultDiv.html(JSON.stringify(data));
            }).fail(function (jqXHR, textStatus, errorThrown) {
                resultDiv.html(errorThrown);
        });
    });

    $("#create-product-submit").on("click", function () {
        var url = "/api/products/";
        var parent = $("#create-product");
        var resultDiv = $("#create-product-result");
        var id = parent.find("[name=Id]").val();
        var model = parent.find("[name=Model]").val();
        var brand = parent.find("[name=Brand]").val();
        var desc = parent.find("[name=Description]").val();

        var data = { id: id, model: model, brand: brand, description: desc};
        $.ajax({
            url: url,
            method: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + accessToken);
            },
        }).done(function (data) {
            console.log(data);
            resultDiv.html(JSON.stringify(data));
        }).fail(function (jqXHR, textStatus, errorThrown) {
            resultDiv.html(errorThrown);
        });
    });

    $("#update-product-submit").on("click", function () {
        var url = "/api/products/";
        var parent = $("#update-product");
        var resultDiv = $("#update-product-result");
        var id = parent.find("[name=Id]").val();
        var model = parent.find("[name=Model]").val();
        var brand = parent.find("[name=Brand]").val();
        var desc = parent.find("[name=Description]").val();
        url += id;

        var data = { id: id, model: model, brand: brand, description: desc };
        $.ajax({
            url: url,
            method: "PUT",
            data: JSON.stringify(data),
            contentType: "application/json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + accessToken);
            },
        }).done(function (data) {
            resultDiv.html("OK");
        }).fail(function (jqXHR, textStatus, errorThrown) {
            resultDiv.html(errorThrown);
        });
    });

    $("#delete-submit").on("click", function () {
        var url = "/api/products/";
        var parent = $("#delete");
        var resultDiv = $("#delete-result");
        var id = parent.find("[name=Id]").val();
        url += id;

        $.ajax({
            url: url,
            method: "DELETE",
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', "Bearer " + accessToken);
            },
        }).done(function (data) {
            resultDiv.html("OK");
        }).fail(function (jqXHR, textStatus, errorThrown) {
            resultDiv.html(errorThrown);
        });
    });
});