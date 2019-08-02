
function Quotationss() {
    //alert("User");
    // $("#modal-form").modal("");
    $("#UpdateQuotationss").hide();
    $("#InsertQuotationss").show();

    // $("#UpdateUser").show();

    GetQuotation();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Date").val("");
    $("#Refeno").val("");

    $("#Notes").val("");
    $("#Status").val("Pending");
    $("#Customerss").val("Bilal Ahmad");
    $("#Supplliers").val("Ali");
    
    $("#Total").val("");

    //$("#Rid").val("");
    // $("#Roles").val("");

}

function AddQuotationss() {

    // alert("Add Purchage");
    //debugger;

    // $("#Role").hide();
    var formdata = $("#AddQuotationss").serialize();
    var Suppliers = $("#Suppliers").val();
    var Customer = $("#Customer").val();
    
   // var Barcode = $("#Code").val();


    $.ajax({
        type: "POST",
        url: "/Quotationss/AddQuotationss?Suppliers=" + Suppliers + "?Customer=" + Customer ,
        //  url: "Roles/AddRole",
        data: formdata,
        success: function (result) {
            //console.log(result);
            $("#modal-form").modal("hide");
            GetQuotation();

        },
        error: function (result) {
        }
    });


}
$(window).load(function () {
    GetQuotation();

});
window.GetQuotation = function () {
    //alert();
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetQuotation tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $.ajax({
        type: "GET",
        url: "/Quotationss/GetQuotationss",
        success: function (result) {
            //  debugger;
            var row = '';
            $("#GetQuotation").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.date + "</td><td>" + v.refeno + "</td><td>" + v.biller + "</td><td>" + v.customerss.name + "</td><td>" + v.total + "</td><td>" + v.status + "</td><td>" +
                    '<a href="#" onclick="FindQuotationss(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteQuotationss(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetQuotation").append(row);

        },
        error: function (result) {
            alert("Error");
            alertify.error(result.responseText);

        }
    });
}
//$(window).load(function () {
//    GetCheck();

//});
//window.GetCheck = function () {
//    $("#retail").on("input", function () {
//        alert("hello");
//        $("#SubTotal").val($("#Retail_Price").val() * $("#Quantity").val() );
      
//    });
//}

function FindQuotationss(id) {
   // alert("Find Pur");
    // debugger;
    //$("#Roles").hide();
    //$("#Role").show();
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertQuotationss").hide();
    $("#UpdateQuotationss").show();

    $.ajax({

        url: "/Quotationss/FindQuotationss",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (result) {
           //   debugger;
            $("#Date").val(result.data);
            $("#Refeno").val(result.refeno);
        
            $("#Notes").val(result.notes);
           
            $("#Status option[value='" + result.status + "']").prop('selected', true);
            $("#Customer option[value='" + result.customerss.id + "']").prop('selected', true);
            $("#Suppliers option[value='" + result.suppllierss.id + "']").prop('selected', true);
            $("#Total").val(result.total);
          
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alert("Error");
            alertify.error(data);
        }
    });
}
function UpdatesQuotationd() {
    //alert("Update");
    //debugger;
    var formdata = $("#AddQuotationss").serialize();
    var Suppliers = $("#Suppliers").val();
    var Customer = $("#Customer").val();

    // var Barcode = $("#Code").val();


    $.ajax({
        type: "POST",
        url: "/Quotationss/UpdateQuotationss?Suppliers=" + Suppliers + "?Customer=" + Customer,
        
        data: formdata,
        // url: "/User/AddUser
        success: function (result) {
            // result.n
            $("#modal-form").modal("hide");
            //GetUser();
            GetQuotation();
        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
function DeleteQuotationss(id) {
    confirm("Are you sure you want want to delete this Quotationss");
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Quotationss/DeleteQuotationss?Id=" + row_id + "",
        success: function (data) {
            GetQuotation();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function Quotation() {
    var c = null;
    // alert("Check");
    // debugger;
    //var id = 
    //var row_id = $(id).data('id');
    //$("#Barcode").val(row_id);
    var Barcode = $("#Code").val();
    var formdata = { id: Barcode };

    $.ajax({

       
        type: "Get",
       url: "/Quotationss/PurchasessItemf",
      //  url: "/Item/GetItem",
        data: formdata,
        dataType: "Json",

        success: function (result) {
            var row = '';
           // $("#GetQuotation").html('');
          //  var total = null;
           
                var total = null;
               // total = 
            row += "<tr><td>" + result.name + "</td><td><input  style='width: 120px; ' class='check' id='Quantity' value='1'></td><td><input style='width: 120px; ' type='text' id='retail' value=" + result.retail_Price + "></td><td><input type='text' id='SubTotal' class='intro' style='width: 120px; ' value=" + result.retail_Price + "></div></td></tr>";
            
            debugger
            var total = result.retail_Price;
            
            c = total + c;
           
            $("#GetQuotationss").append(row);
           
            //$("input.check").bind("input.check", function () {
            //    // alert("check");
            //    $("input.intro").val(parseInt($(this).val()) * parseInt($("#retail").val()));
            //});
            $("input.check,input.intro").bind("input.intro", function () {
                // alert("check");
                $("input.intro").val(parseInt($(this).val()) * 10);
            });
            $("#Total").val(c);
           
        },
        error: function (data) {
            alert("Error");
            alertify.error(data);
        }
    });

}
