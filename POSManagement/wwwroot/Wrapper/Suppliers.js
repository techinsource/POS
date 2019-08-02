function Suppliers() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateSuppliers").hide();
    $("#InsertSuppliers").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Email").val("");
    $("#Mobile").val("");
    $("#Address").val("");

}


function AddSuppliers() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddSuppliers").serialize();
    //$("#UpdateRole").hide();
    // $("#saveRole").hide();

    // debugger;

    $.ajax(
        {
            type: "POST",
            url: "/Suppliers/AddSuppliers",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetSuppliers();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}

function EditSuppliers() {
    //  alert("Update LineItem");
    debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddSuppliers").serialize();
    $.ajax({
        type: "Post",
        url: "/Suppliers/UpdateSuppliers",
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetSuppliers();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}

$(window).load(function () {
    GetSuppliers();

});
window.GetSuppliers = function () {
    //alert("Get line Item");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetSuppliers tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Suppliers/GetSuppliers",
        success: function (result) {
           // console.log(result);
            // debugger;
            var row = '';
            $("#GetSuppliers").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.name + "</td><td>" + v.email + "</td><td>" + v.mobile + "</td><td>" + v.address + "</td><td>" +
                    '<a href="#" onclick="FindSuppliers(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteSuppliers(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetSuppliers").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindSuppliers(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertSuppliers").hide();
    $("#UpdateSuppliers").show();
    $.ajax({

        url: "/Suppliers/FindSuppliers",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Name").val(data.name);
            $("#Email").val(data.email);
            $("#Mobile").val(data.mobile);
            $("#Address").val(data.address);

            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}




function DeleteSuppliers(id) {

    confirm("Are you sure you want want to delete this Suppliers");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Suppliers/DeleteSuppliers?Id=" + row_id + "",
        success: function (data) {
            GetSuppliers();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
