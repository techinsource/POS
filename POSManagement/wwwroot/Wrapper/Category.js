function Category() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateCategory").hide();
    $("#InsertCategory").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#Sortorder").val("");
    $("#Comments").val("");

}


function AddCategory() {
    //  alert("Add LineItem");
    debugger;
    var formdata = $("#AddCategory").serialize();
    var litm = $("#litm").val()
    $.ajax(
        {
            type: "POST",
            url: "/Category/AddCategory?litm=" + litm,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetCategory();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetCategory();

});
window.GetCategory = function () {
   // alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetCategory tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Category/GetCategory",
        success: function (result) {
            //  console.log(result);
            // debugger;
            var row = '';
            $("#GetCategory").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.lineItemDefinition.name + "</td><td>" + v.sortorder + "</td><td>" + v.comments + "</td><td>" +
                    '<a href="#" onclick="FindCategory(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteCategory(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetCategory").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindCategory(id) {
    alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertCategory").hide();
    $("#UpdateCategory").show();
    $.ajax({

        url: "/Category/FindCategory",
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
            $("#litm option[value='" + data.lineItemDefinition.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function CategoryUpdate() {
   
    var formdata = $("#AddCategory").serialize();
    var litm = $("#litm").val()
    $.ajax({
        type: "Post",
        url: "/Category/UpdateCategory?litm=" + litm,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetCategory();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteCategory(id) {

    confirm("Are you sure you want want to delete this Category");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Category/DeleteCategory?Id=" + row_id + "",
        success: function (data) {
            GetSubCategory();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
