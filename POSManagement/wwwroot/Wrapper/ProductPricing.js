//function modelProductPricing() {
//    //alert("User");
//    // $("#modal-form").modal("");
//    $("#UpdateProductPricing").hide();
//    $("#AddProductPricing").hide();

//    // $("#UpdateUser").show();
//    $("#foramdata").hide();
//    GetProductPricing();
//    clear();

//}
//function clear() {
//    $("#Id").val("");
//    $("#Name").val("");
//    $("#Barcode").val("");
//    $("#Price").val("");

//    $("#Expirydate").val("");
//    $("#Category").val("");

//    //$("#Rid").val("");
//    // $("#Roles").val("");

//}

//function AddProductPricing() {

//    //alert("Add Product Pricng");
//    //debugger;

//    // $("#Role").hide();
//    var formdata = $("#ProductPricing").serialize();
//    var Category = $("#Category").val();
//   // var Barcode = $("#Barcode").val();


//    $.ajax({
//        type: "POST",
//        url: "/ProductPricing/AddProductPricing?Category=" + Category,
//        //  url: "Roles/AddRole",
//        data: formdata,
//        success: function (result) {
//            //console.log(result);
//            $("#modal-form").modal("hide");
//            GetProductPricing();

//        },
//        error: function (result) {
//        }
//    });


//}
////$(window).load(function () {
////    GetProductPricing();

////});
////window.GetProductPricing = function () {
////    //alert("Purchage");
////    //debugger;

////    $.ajax({
////        type: "GET",
////        url: "/ProductPricing/GetProductPricing",
////        success: function (result) {
////            debugger;
////            // console.log(result);
////            var row = '';
////            $("#GetProductPricing").html('');

////            $.each(result, function (i, v) {
////                row += "<tr><td>" + v.id + "</td><td>" + v.product.name + "</td><td>" + v.product.price + "</td><td>" + v.profitmargin + "</td><td>" + v.discount + "</td><td>" + v.finalsellingprice + "</td><td>" +
////                    '<a href="#" onclick="FindProductPricing(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteProductPricing(this)" data-id="' + v.id +
////                    '">Delete</a>' + "</td></tr>";


////            });
////            $("#GetProductPricing").append(row);

////        },
////        error: function (result) {
////            alert("Error");
////            alertify.error(result.responseText);

////        }
////    });
////}
//function FindProductPricing(id) {
//    alert("Find Pur");
//    //debugger;
//    //$("#Roles").hide();
//    //$("#Role").show();
//    var row_id = $(id).data('id');
    
//    var formdata = { Id: row_id };
//    $("#foramdata").show();
//    $("#Categorys").hide();
//    $("#AddProductPricing").hide();
//    $("#UpdateProductPricing").show();

//    $.ajax({

//        url: "/ProductPricing/FindProductPricing",
//        type: "Get",
//        data: formdata,
//        dataType: "Json",

//        success: function (result) {
//            debugger;
//            $("#Id").val(result.id);

//            $("#Name").val(result.product.name);
//            $("#Price").val(result.product.price);
//            $("#Profitmargin").val(result.profitmargin);
//            $("#Discount").val(result.discount);
//            $("#Finalsellingprice").val(result.finalsellingprice);

//            //$("#Quantity").val(result.quantity);


//            $("#modal-form").modal("show");
//        },
//        error: function (data) {
//            alert("Error");
//            alertify.error(data);
//        }
//    });
//}
//function UpdateProductPricing() {
//    //alert("Update");
//    //debugger;

//    //var Suppliers = $("#Suppliers").val();
//  //  var Barcode = $("#Barcode").val();
//    var Category = $("#Category").val();
//    var formdata = $("#ProductPricing").serialize();
//    //first = 1 & second=12 & third=5'
//    $.ajax({
//        type: "Post",
//        url: "/ProductPricing/UpdateProductPricing?Category=" + Category ,
//        data: formdata,
//        // url: "/User/AddUser
//        success: function (result) {
//            // result.n
//            $("#modal-form").modal("hide");
//            //GetUser();
//            GetProductPricing();
//        },

//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}
//function DeleteProductPricing(id) {
//    confirm("Are you sure you want want to delete this Role");
//    var row_id = $(id).data('id');
//    $.ajax({
//        type: "Post",
//        url: "/ProductPricing/DeleteProductPricing?Id=" + row_id + "",
//        success: function (data) {
//            GetProductPricing();
//        },
//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}

//function ProductPricing() {
//    //alert("Check");
//    //debugger;
//    //var id = 
//    //var row_id = $(id).data('id');
//    //$("#Barcode").val(row_id);
//    $("#myInput").on("keyup", function () {

//        var value = $(this).val().toLowerCase();
//        $("#GetProductPricing tr").filter(function () {
//            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//        });
//    });

//    var Category = $("#Category").val();
//    var formdata = { id: Category };
//    $("#modal-form").modal("hide");

//    $.ajax({

//        url: "/ProductPricing/GetProductPricing?Category=" + Category,
//        type: "Get",
//        data: formdata,
//        dataType: "Json",

//        success: function (result) {
//            debugger;
//            console.log(result);
//            // GetPurchageInvoice();
//            debugger
            
//            var row = '';
//            $("#GetProductPricing").html('');

//            $.each(result, function (i, v) {
//                row += "<tr><td>" + v.id + "</td><td>" + v.product.name + "</td><td>" + v.product.price + "</td><td>" + v.profitmargin + "</td><td>" + v.discount + "</td><td>" + v.finalsellingprice + "</td><td>" +
//                    '<a href="#" onclick="FindProductPricing(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteProductPricing(this)" data-id="' + v.id +
//                    '">Delete</a>' + "</td></tr>";


//            });
//            $("#GetProductPricing").append(row);

            
//        },
//        error: function (data) {
//            alert("Error");
//            alertify.error(data);
//        }
//    });

//}
