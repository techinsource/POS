
//function modelPurchageInvoice() {
//    //alert("User");
//    // $("#modal-form").modal("");
//    $("#UpdatePurchageInvoice").hide();
//    $("#AddPurchageInvoice").show();

//    // $("#UpdateUser").show();

//    GetPurchageInvoice();
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

//function AddPurchageInvoice() {

//    alert("Add Purchage");
//    debugger;

//    // $("#Role").hide();
//    var formdata = $("#PurchageInvoice").serialize();
//    var Suppliers = $("#Suppliers").val();
//    var Barcode = $("#Barcode").val();

    
//    $.ajax({
//        type: "POST",
//        url: "/PurchageInvoice/AddPurchageInvoice?Suppliers=" + Suppliers + "?Barcode=" + Barcode,
//        //  url: "Roles/AddRole",
//        data: formdata,
//        success: function (result) {
//            //console.log(result);
//            $("#modal-form").modal("hide");
//            GetPurchageInvoice();

//        },
//        error: function (result) {
//        }
//    });


//}
//$(window).load(function () {
//    GetPurchageInvoice();

//});
//window.GetPurchageInvoice = function () {
//    $("#myInput").on("keyup", function () {

//        var value = $(this).val().toLowerCase();
//        $("#GetPurchageInvoice tr").filter(function () {
//            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//        });
//    });

//    $.ajax({
//        type: "GET",
//        url: "/PurchageInvoice/GetPurchageInvoice",
//        success: function (result) {
//            debugger;
//            // console.log(result);
//            var row = '';
//            $("#GetPurchageInvoice").html('');

//            $.each(result, function (i, v) {
//                row += "<tr><td>" + v.id + "</td><td>" + v.suppliers.name + "</td><td>" + v.product.name + "</td><td>" + v.quantity + "</td><td>" + v.product.price + "</td><td>" + v.totalamount + "</td><td>" + 
//                    '<a href="#" onclick="FindPurchageInvoice(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeletePurchageInvoice(this)" data-id="' + v.id +
//                    '">Delete</a>' + "</td></tr>";


//            });
//            $("#GetPurchageInvoice").append(row);

//        },
//        error: function (result) {
//            alert("Error");
//            alertify.error(result.responseText);

//        }
//    });
//}
//function FindPurchageInvoice(id) {
//    alert("Find Pur");
//    //debugger;
//    //$("#Roles").hide();
//    //$("#Role").show();
//    var row_id = $(id).data('id');
//    $("#Id").val(row_id);
//    var formdata = { Id: row_id };
//    $("#AddPurchageInvoice").hide();
//    $("#UpdatePurchageInvoice").show();

//    $.ajax({

//        url: "/PurchageInvoice/FindPurchageInvoice",
//        type: "Get",
//        data: formdata,
//        dataType: "Json",

//        success: function (result) {
//            debugger;
//            // console.log(result);
//            GetPurchageInvoice();
//            // debugger
//            // $('#Roles option').val('14');
//            // document.querySelector('#Roles').value = "waqar";
//            $("#Suppliers option[value='" + result.suppliers.id + "']").prop('selected', true);
//            $("#Barcode").val(result.product.barcode);
//            $("#Product").val(result.product.name);
//            $("#Price").val(result.product.price);


//            $("#Quantity").val(result.quantity);

        
//            $("#modal-form").modal("show");
//        },
//        error: function (data) {
//            alert("Error");
//            alertify.error(data);
//        }
//    });
//}
//function UpdatePurchageInvoice() {
//    alert("Update");
//     debugger;
    
//    var Suppliers = $("#Suppliers").val();
//    var Barcode = $("#Barcode").val();
//    var formdata = $("#PurchageInvoice").serialize();
//    //first = 1 & second=12 & third=5'
//    $.ajax({
//        type: "Post",
//        url: "/PurchageInvoice/UpdatePurchageInvoice?Suppliers=" + Suppliers + "?Barcode=" + Barcode,
//        data: formdata,
//        // url: "/User/AddUser
//        success: function (result) {
//            // result.n
//            $("#modal-form").modal("hide");
//            //GetUser();
//            GetPurchageInvoice();
//        },

//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}
//function DeletePurchageInvoice(id) {
//    confirm("Are you sure you want want to delete this Role");
//    var row_id = $(id).data('id');
//    $.ajax({
//        type: "Post",
//        url: "/PurchageInvoice/DeletePurchageInvoice?Id=" + row_id + "",
//        success: function (data) {
//            GetPurchageInvoice();
//        },
//        error: function (xhr) {
//            alertify.error(xhr.responseText);
//        }
//    });
//}

//function checkdatac() {
//    alert("Check data");
//    debugger;
//    //var id = 
//    //var row_id = $(id).data('id');
//    //$("#Barcode").val(row_id);
//    var Barcode = $("#Barcode").val();
//    var formdata = { id: Barcode };

//    $.ajax({

//        url: "/PurchageInvoice/ProductPurchageInvoice",
//        type: "Get",
//        data: formdata,
//        dataType: "Json",

//        success: function (result) {
//            debugger;
//            console.log(result);
//           // GetPurchageInvoice();
//            debugger
//          //  $('#Roles option').val('14');
//           // document.querySelector('#Roles').value = "waqar";
//            // $("#Suppliers option[value='" + result.suppliers.id + "']").prop('selected', true);
//           // $("#Barcode").val(result.product.barcode);
//            $("#Product").val(result.name);
//            $("#Price").val(result.price);


//            //$("#Quantity").val(result.quantity);


//            //$("#modal-form").modal("show");
//        },
//        error: function (data) {
//            alert("Error");
//            alertify.error(data);
//        }
//    });

//}
