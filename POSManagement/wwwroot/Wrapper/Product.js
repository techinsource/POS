//function modelProduct() {
//    //alert("User");
//    // $("#modal-form").modal("");
//    $("#UpdateProduct").hide();
//    $("#AddProduct").show();

//    // $("#UpdateUser").show();
    
//    GetProduct();
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

//function AddProduct() {

//   // alert("Add Product");
//   debugger;

//    // $("#Role").hide();
//    var formdata = $("#Product").serialize();
//    var Category = $("#Category").val();
//    $.ajax({
//        type: "POST",
//        url: "/Product/AddProduct?Category=" + Category,
//        //  url: "Roles/AddRole",
//        data: formdata,
//        success: function (result) {
//            //console.log(result);
//            $("#modal-form").modal("hide");
//            GetUser();

//        },
//        error: function (result) {
//        }
//    });


//}
//$(window).load(function () {
//    GetProduct();

//});
//window.GetProduct = function () {
//    //debugger;
//    $("#myInput").on("keyup", function () {
        
//        var value = $(this).val().toLowerCase();
//        $("#GetProduct tr").filter(function () {
//            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//        });
//    });

//    $.ajax({
//        type: "GET",
//        url: "/Product/GetProduct",
//        success: function (result) {
//            // console.log(result);
//            var row = '';
//            $("#GetProduct").html('');

//            $.each(result, function (i, v) {
//                row += "<tr><td>" + v.id + "</td><td>" + v.name + "</td><td>" + v.barcode + "</td><td>" + v.price + "</td><td>" + v.expirydate + "</td><td>" + v.category.name + "</td><td>" +
//                    '<a href="#" onclick="FindProduct(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteProduct(this)" data-id="' + v.id +
//                    '">Delete</a>' + "</td></tr>";


//            });
//            $("#GetProduct").append(row);

//        },
//        error: function (result) {
//            alert("Error");
//            alertify.error(result.responseText);

//        }
//    });
//}
//function FindProduct(id) {
//    //alert("Find User");
//    //debugger;
//    //$("#Roles").hide();
//    //$("#Role").show();
//    var row_id = $(id).data('id');
//    $("#Id").val(row_id);
//    var formdata = { Id: row_id };
//    $("#AddProduct").hide();
//    $("#UpdateProduct").show();

//    $.ajax({

//        url: "/Product/FindProduct",
//        type: "Get",
//        data: formdata,
//        dataType: "Json",

//        success: function (result) {

//            // console.log(result);
//            GetUser();
//            // debugger
//            // $('#Roles option').val('14');
//            // document.querySelector('#Roles').value = "waqar";
//            $("#Name").val(result.name);
//            $("#Barcode").val(result.barcode);
//            $("#Price").val(result.price);
//            $("#Expirydate").val(result.password);

//            $("#Category option[value='" + result.category.id + "']").prop('selected', true);
//            $("#modal-form").modal("show");
//        },
//        error: function (data) {
//            alert("Error");
//            alertify.error(data);
//        }
//    });
//}
//function UpdateProduct() {
//    // debugger;
//    var Category= $("#Category").val();
//    var formdata = $("#Product").serialize();
//    //first = 1 & second=12 & third=5'
//    $.ajax({
//        type: "Post",
//        url: "/Product/UpdateProduct?Category=" + Category,
//        data: formdata,
//        // url: "/User/AddUser
//        success: function (result) {
//            // result.n
//            $("#modal-form").modal("hide");
//            //GetUser();
//            GetProduct();
//        },

//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}
//function DeleteProduct(id) {
//    confirm("Are you sure you want want to delete this Role");
//    var row_id = $(id).data('id');
//    $.ajax({
//        type: "Post",
//        url: "/Product/DeleteProduct?Id=" + row_id + "",
//        success: function (data) {
//            GetProduct();
//        },
//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}

