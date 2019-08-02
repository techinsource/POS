function LineItem() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateLineItem").hide();
    $("#InsertLineItem").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Barcode").val("");
    $("#Sortorder").val("");
    $("#Comments").val("");

}


function AddLineItem() {
 //  alert("Add LineItem");
   // debugger;
    var formdata = $("#AddLineItem").serialize();
   

    // debugger;

    $.ajax(
        {
            type: "POST",
            url: "/Lineitemdefinition/AddLineitemdefinition",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetLineItem();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}

function LineItemd() {
  //  alert("Update LineItem");
    debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddLineItem").serialize();
    $.ajax({
        type: "Post",
        url: "/Lineitemdefinition/UpdateLineitemdefinition",
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetLineItem();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}

$(window).load(function () {
    GetLineItem();

});
window.GetLineItem = function () {
    //alert("Get line Item");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetLineItem tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Lineitemdefinition/GetLineitemdefinition",
        success: function (result) {
            console.log(result);
            // debugger;
            var row = '';
            $("#GetLineItem").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.id + "</td><td>" + v.name + "</td><td>" + v.barcode + "</td><td>" + v.sortorder + "</td><td>" + v.comments + "</td><td>" +
                    '<a href="#" onclick="FindLineItem(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteLineItem(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetLineItem").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindLineItem(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertLineItem").hide();
    $("#UpdateLineItem").show();
    $.ajax({

        url: "/Lineitemdefinition/FindLineitemdefinition",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Name").val(data.name);
            $("#Barcode").val(data.barcode);
            $("#Sortorder").val(data.sortorder);
            $("#Comments").val(data.comments);

            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}




function DeleteLineItem(id) {

    confirm("Are you sure you want want to delete this Line Item");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Lineitemdefinition/DeleteLineitemdefinition?Id=" + row_id + "",
        success: function (data) {
            GetLineItem();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
