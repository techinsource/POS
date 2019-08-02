function ItemGroup() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateItemGroup").hide();
    $("#InsertItemGroup").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#SortItem").val("");
    $("#Comments").val("");

}


function AddItemGroup() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddItemGroup").serialize();
    var litm = $("#litm").val()
    $.ajax(
        {
            type: "POST",
            url: "/ItemGroup/AddItemGroup?litm=" + litm,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetItemGroup();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetItemGroup();

});
window.GetItemGroup = function () {
    //alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetItemGroup tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/ItemGroup/GetItemGroup",
        success: function (result) {
            //  console.log(result);
            // debugger;
            var row = '';
            $("#GetItemGroup").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.lineItemDefinition.name + "</td><td>" + v.sortItem + "</td><td>" + v.comments + "</td><td>" +
                    '<a href="#" onclick="FindItemGroup(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteItemGroup(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetItemGroup").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindItemGroup(id) {
     alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertItemGroup").hide();
    $("#UpdateItemGroup").show();
    $.ajax({

        url: "/ItemGroup/FindItemGroup",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);
            $("#Code").val(data.code);
            $("#SortItem").val(data.sortItem);
            $("#Comments").val(data.comments);
            $("#litm option[value='" + data.lineItemDefinition.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function ItemGroupUpdate() {
   // alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddItemGroup").serialize();
    var litm = $("#litm").val()
    $.ajax({
        type: "Post",
        url: "/ItemGroup/UpdateItemGroup?litm=" + litm,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetItemGroup();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteItemGroup(id) {

    confirm("Are you sure you want want to delete this ItemGroup");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/ItemGroup/DeleteItemGroup?Id=" + row_id + "",
        success: function (data) {
            GetItemGroup();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
