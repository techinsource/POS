function UsersGroup() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateUsersGroup").hide();
    $("#InsertUsersGroup").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");

}


function AddUsersGroup() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddUsersGroup").serialize();
    //$("#UpdateRole").hide();
    // $("#saveRole").hide();

    // debugger;

    $.ajax(
        {
            type: "POST",
            url: "/UsersGroup/AddUsersGroup",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetUsersGroup();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}

function UsersGroupUpdate() {
    //  alert("Update LineItem");
    debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddUsersGroup").serialize();
    $.ajax({
        type: "Post",
        url: "/UsersGroup/UpdateUsersGroup",
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetUsersGroup();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}

$(window).load(function () {
    GetUsersGroup();

});
window.GetUsersGroup = function () {
    //alert("Get line Item");
   // debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetUsersGroup tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/UsersGroup/GetUsersGroup",
        success: function (result) {
           // console.log(result);
           //  debugger;
            var row = '';
            $("#GetUsersGroup").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.name + "</td><td>" + v.totaluser + "</td><td>" +
                    '<a href="#" onclick="FindUsersGroup(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteUsersGroup(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetUsersGroup").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindUsersGroup(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertUsersGroup").hide();
    $("#UpdateUsersGroup").show();
    $.ajax({

        url: "/UsersGroup/FindUsersGroup",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Name").val(data.name);

            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}




function DeleteUsersGroup(id) {

    confirm("Are you sure you want want to delete this UsersGroup");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/UsersGroup/DeleteUsersGroup?Id=" + row_id + "",
        success: function (data) {
            GetUsersGroup();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
