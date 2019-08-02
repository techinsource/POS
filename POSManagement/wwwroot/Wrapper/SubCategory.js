function SubCategory() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateSubCategory").hide();
    $("#InsertSubCategory").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#Sortorder").val("");
    $("#Comments").val("");

}


function AddSubCategory() {
    //  alert("Add LineItem");
    debugger;
    var formdata = $("#AddSubCategory").serialize();
    var cat = $("#cat").val()
    $.ajax(
        {
            type: "POST",
            url: "/SubCategory/AddSubCategory?cat=" + cat,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetSubCategory();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetSubCategory();

});
window.GetSubCategory = function () {
    // alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetSubCategory tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/SubCategory/GetSubCategory",
        success: function (result) {
            //  console.log(result);
            // debugger;
            var row = '';
            $("#GetSubCategory").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.category.name + "</td><td>" + v.sortorder + "</td><td>" + v.comments + "</td><td>" +
                    '<a href="#" onclick="FindSubCategory(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteSubCategory(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetSubCategory").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindSubCategory(id) {
   // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertSubCategory").hide();
    $("#UpdateSubCategory").show();
    $.ajax({

        url: "/SubCategory/FindSubCategory",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);
            $("#Code").val(data.code);
            $("#Sortorder").val(data.sortorder);
            $("#Comments").val(data.comments);
            $("#cat option[value='" + data.category.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function SubCategoryUpdate() {
    // alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddSubCategory").serialize();
    var cat = $("#cat").val()
    $.ajax({
        type: "Post",
        url: "/SubCategory/UpdateSubCategory?cat=" + cat,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetSubCategory();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteSubCategory(id) {

    confirm("Are you sure you want want to delete this SubCategory");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/SubCategory/DeleteSubCategory?Id=" + row_id + "",
        success: function (data) {
            GetCategory();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
