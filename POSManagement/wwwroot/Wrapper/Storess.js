
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#Cost_Price").val("");
    $("#Retail_Price").val("");

}


function AddStoress() {
      alert("Add LineItem");
     debugger;
    var formdata = $("#AddStoress").serialize();
    var Userss = $("#Userss").val()
    $.ajax(
        {
            type: "POST",
            url: "/Storess/AddStoress?Userss=" + Userss,

            data: formdata,

            success: function (data) {

                //$("#modal-form").modal("hide");
                GetStoress();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetStoress();

});
window.GetStoress = function () {
    //alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetStoress tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Storess/GetStoress",
        success: function (result) {
            // console.log(result);
              debugger;
            var row = '';
            $("#GetStoress").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.name + "</td><td>" + v.country + "</td><td>" + v.address + "</td><td>" + v.createdOn + "</td><td>" +
                    '<a href="#" onclick="FindStoress(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteStoress(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetStoress").append(row);
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


function DeleteStoress(id) {

    confirm("Are you sure you want want to delete this Storess");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Storess/DeleteStoress?Id=" + row_id + "",
        success: function (data) {
            GetStoress();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
