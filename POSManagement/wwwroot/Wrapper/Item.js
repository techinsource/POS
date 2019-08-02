function Item() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateItem").hide();
    $("#InsertItem").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#Cost_Price").val("");
    $("#Retail_Price").val("");

}


function AddItem() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddItem").serialize();
  var  litm = $("#litm").val()
    $.ajax(
        {
            type: "POST",
            url: "/Item/AddItem?litm=" + litm,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetItem();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetItem();

});
window.GetItem = function () {
    //alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetItem tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Item/GetItem",
        success: function (result) {
         // console.log(result);
          //  debugger;
            var row = '';
            $("#GetItem").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.lineItemDefinition.name + "</td><td>" + v.cost_Price + "</td><td>" + v.retail_Price + "</td><td>" +
                    '<a href="#" onclick="FindItem(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteItem(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetItem").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindItem(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertItem").hide();
    $("#UpdateItem").show();
    $.ajax({

        url: "/Item/FindItem",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);
            $("#Code").val(data.code);
            $("#Cost_Price").val(data.cost_Price);
            $("#Retail_Price").val(data.retail_Price);
            $("#litm option[value='" + data.lineItemDefinition.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function Itemupdate() {
    alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddItem").serialize();
    var litm = $("#litm").val()
    $.ajax({
        type: "Post",
        url: "/Item/UpdateItem?litm=" + litm,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetItem();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteItem(id) {

    confirm("Are you sure you want want to delete this Line Item");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Item/DeleteItem?Id=" + row_id + "",
        success: function (data) {
            GetItem();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
