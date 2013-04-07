/// <reference path="_references.js" />
var dataLocation = 'http://grocerybuddydata.azurewebsites.net';
//var dataLocation = 'http://localhost:54328';

/// Class to represent a product
var Product = function (id, sku, name, description, isDeleted, isNew) {
    var self = this;

    // #region Properties
    Id: ko.observable(id);
    Sku: ko.observable(sku);
    Name: ko.observable(name);
    Description: ko.observable(description);
    IsDeleted: ko.observable(isDeleted);
    IsNew: ko.observable(isNew);
    // #endregion Properties

    return self;
};

function jsonp(url, callback) {
    // create a unique id
    var id = "_" + (new Date()).getTime();

    // create a global callback handler
    window[id] = function (result) {
        // forward the call to specified handler                                       
        if (callback)
            callback(result);

        // clean up: remove script and id
        var sc = document.getElementById(id);
        sc.parentNode.removeChild(sc);
        window[id] = null;
    }

    url = url.replace("callback=?", "callback=" + id);

    // create script tag that loads the 'JSONP script' 
    // and executes it calling window[id] function                
    var script = document.createElement("script");
    script.setAttribute("id", id);
    script.setAttribute("src", url);
    script.setAttribute("type", "text/javascript");
    document.body.appendChild(script);
}

var viewModel =
{
    products: ko.observableArray([]),
    selectedProduct: ko.observable(null),

    selectProduct: function (product) {
        viewModel.selectedProduct(this);
        $(".right-section").show();
    },
    newProduct: function () {
        this.products.push({
                Id: ko.observable(this.products().length + 1),
                Sku: ko.observable(this.products().length + 1),
                Name: ko.observable("New " + this.products().length),
                Description: ko.observable("Description " + this.products().length),
                IsNew: ko.observable(true)
            });
        //this.products.push(
        //    new Product(
        //        this.products().length + 1
        //        , this.products().length + 1
        //        , "New " + this.products().length
        //        , "Description " + this.products().length
        //        , false, true
        //    ));
    }
}

$(document).ready(function () {
    $(".right-section").hide();
    refreshProducts();

    function refreshProducts() {
        jsonp((dataLocation + "/api/Products?callback=?"),
               function (data) {
                   $.each(data, function (index) {
                       viewModel.products.push(toProductKoObservable(data[index]));
                   });
                   ko.applyBindings(viewModel);
               });
    }

    function toProductKoObservable(product) {
        //return new Product(
        //    product.Id
        //    , product.Sku
        //    , product.Name
        //    , product.Description
        //    , false
        //    , false
        //    );
        return {
            Id: ko.observable(product.Id),
            Sku: ko.observable(product.Sku),
            Name: ko.observable(product.Name),
            Description: ko.observable(product.Description),
            IsDeleted: ko.observable(product.IsDeleted)
        };
    }

    $("#saveAll").click(function () {
        var saveData = ko.toJS(viewModel.products);
        $.each(saveData, function (index) {
            var current = saveData[index];
            var action = "PUT";
            var stringyF = JSON.stringify(current);
            var vUrl = "/api/Products?Id=" + current.Id;
            if (current.IsNew) {
                action = "POST";
                vUrl = "/api/Products";
            }
            $.ajax(
            {
                url: vUrl,
                contentType: "application/json;charset=utf-8",
                type: action,
                data: JSON.stringify(current),
                success: function () {
                },
                error: function (data) {
                    alert("ERROR");
                }
            });
        });
    });
});