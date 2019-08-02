
function Purchasess() {
    //alert("User");
    // $("#modal-form").modal("");
    $("#UpdatePurchasess").hide();
    $("#InsertPurchasess").show();

    // $("#UpdateUser").show();

    GetPurchasess();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Date").val("");
    $("#Referenceno").val("");
    $("#Notes").val("");
   // $("#Suppliers option[value='" + result.suppliers.id + "']").prop('selected', false);
    $("#Code").val("");
    $("#Quantity").val("");

    //$("#Rid").val("");
    // $("#Roles").val("");

}

function AddPurchasess() {

   /// alert("Add Purchage");
    debugger;

    // $("#Role").hide();
    var formdata = $("#AddPurchasess").serialize();
    var Suppliers = $("#Suppliers").val();
    var Barcode = $("#Code").val();


    $.ajax({
        type: "POST",
        url: "/Purchase/AddPurchasess?Suppliers=" + Suppliers + "?Code=" + Barcode,
        //  url: "Roles/AddRole",
        data: formdata,
        success: function (result) {
            //console.log(result);
            $("#modal-form").modal("hide");
            GetPurchasess();

        },
        error: function (result) {
        }
    });


}
$(window).load(function () {
    GetPurchasess();

});
window.GetPurchasess = function () {
    //alert();
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetPurchasess tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $.ajax({
        type: "GET",
        url: "/Purchase/GetPurchasess",
        success: function (result) {
          //  debugger;
            // console.log(result);
            var row = '';
            $("#GetPurchasess").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.date + "</td><td>" + v.referenceno + "</td><td>" + v.suppliers.name + "</td><td>" + v.totalamount + "</td><td>" + v.totalamount + "</td><td>" +
                    ' <a href="#" onclick="DeletePurchasess(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetPurchasess").append(row);

        },
        error: function (result) {
            alert("Error");
            alertify.error(result.responseText);

        }
    });
}
function FindPurchasess(id) {
    alert("Find Pur");
   // debugger;
    //$("#Roles").hide();
    //$("#Role").show();
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertPurchasess").hide();
    $("#UpdatePurchasess").show();

    $.ajax({

        url: "/Purchase/FindPurchasess",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (result) {
          //  debugger;
           
            // document.querySelector('#Roles').value = "waqar";
            $("#Date").val(result.data);
            $("#Referenceno").val(result.referenceno);
            $("#Notes").val(result.notes);
            $("#Suppliers option[value='" + result.suppliers.id + "']").prop('selected', true);
            $("#Code").val(result.item.code);
            $("#Quantity").val(result.quantity);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alert("Error");
            alertify.error(data);
        }
    });
}
function UpdatePurchageInvoice() {
    alert("Update");
    debugger;

    var Suppliers = $("#Suppliers").val();
    var Barcode = $("#Barcode").val();
    var formdata = $("#PurchageInvoice").serialize();
    //first = 1 & second=12 & third=5'
    $.ajax({
        type: "Post",
        url: "/PurchageInvoice/UpdatePurchageInvoice?Suppliers=" + Suppliers + "?Barcode=" + Barcode,
        data: formdata,
        // url: "/User/AddUser
        success: function (result) {
            // result.n
            $("#modal-form").modal("hide");
            //GetUser();
            GetPurchageInvoice();
        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
function DeletePurchasess(id) {
    confirm("Are you sure you want want to delete this Purchase");
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Purchase/DeletePurchasess?Id=" + row_id + "",
        success: function (data) {
            GetPurchasess();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}

function PurchaseCode() {
   // alert("Check");
   // debugger;
    //var id = 
    //var row_id = $(id).data('id');
    //$("#Barcode").val(row_id);
    var Barcode = $("#Code").val();
    var formdata = { id: Barcode };

    $.ajax({

        url: "/Purchase/PurchasessItemf",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (result) {
            debugger;
            console.log(result);
            // GetPurchageInvoice();
            debugger
            //  $('#Roles option').val('14');
            // document.querySelector('#Roles').value = "waqar";
            // $("#Suppliers option[value='" + result.suppliers.id + "']").prop('selected', true);
            $("#Item").val(result.name);
            $("#Cost_Price").val(result.cost_Price);
            $("#Retail_Price").val(result.retail_Price);


            //$("#Quantity").val(result.quantity);


            //$("#modal-form").modal("show");
        },
        error: function (data) {
            alert("Error");
            alertify.error(data);
        }
    });

}
