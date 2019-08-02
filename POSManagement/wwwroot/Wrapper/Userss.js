function Userss() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateUserss").hide();
    $("#InsertUserss").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Email").val("");
    $("#Mobile").val("");
    $("#Address").val("");
    $("#Password").val("");
  //  $("#IsActive").val("");
}


function AddUserss() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddUserss").serialize();
    var userg = $("#userg").val()
    $.ajax(
        {
            type: "POST",
            url: "/Userss/AddUserss?userg=" + userg,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetUserss();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetUserss();

});
window.GetUserss = function () {
    //alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetUserss tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Userss/GetUserss",
        success: function (result) {
            // console.log(result);
            //  debugger;
            var row = '';
            $("#GetUserss").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.name + "</td><td>" + v.userssGroups.name + "</td><td>" + v.email + "</td><td>" + v.mobile + "</td><td>" + v.address + "</td><td>" + v.password + "</td><td>" + v.isActive + "</td><td>" +
                    '<a href="#" onclick="FindUserss(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteUserss(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetUserss").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindUserss(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertUserss").hide();
    $("#UpdateUserss").show();
    $.ajax({

        url: "/Userss/FindUserss",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);
            $("#Email").val(data.email);
            $("#Mobile").val(data.mobile);
            $("#Address").val(data.address);
            $("#Password").val(data.password);
            // $("#IsActive").val(data.isActive);
            $("#IsActive option[value='" + data.isActive + "']").prop('selected', true);
            $("#userg option[value='" + data.userssGroups.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function UserssUpdate1() {
    alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddUserss").serialize();
    var userg = $("#userg").val()
    $.ajax({
        type: "Post",
        url: "/Userss/UpdateUserss?userg=" + userg,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetUserss();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteUserss(id) {

    confirm("Are you sure you want want to delete this Userss");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Userss/DeleteUserss?Id=" + row_id + "",
        success: function (data) {
            GetUserss();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
