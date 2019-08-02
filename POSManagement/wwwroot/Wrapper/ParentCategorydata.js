function ParentCategory() {
   // alert();
    // $("#modal-form").modal("");
    $("#UpdateParentCategory").hide();
    $("#InsertParentCategory").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");

}


function AddParentCategory() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddParentCategory").serialize();


    // debugger;

    $.ajax(
        {
            type: "POST",
            url: "/ParentCategory/AddParentCategory",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetParentCategory();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}


$(window).load(function () {
    GetParentCategory();

});
window.GetParentCategory = function () {
   // alert("Parent");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetParentCategory tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/ParentCategory/GetParentCategory",
        success: function (result) {
            // console.log(result);
            // debugger;
            var row = '';
            $("#GetParentCategory").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>"+  v.id + "</td><td>"  + v.name + "</td><td>"  +
                    '<a href="#" onclick="FindParentCategory(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteParentCategory(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetParentCategory").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindParentCategory(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertParentCategory").hide();
    $("#UpdateParentCategory").show();
    $.ajax({

        url: "/ParentCategory/FindParentCategory",
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



function UpdateParentCategorys() {
      alert("Add LineItem");
    // debugger;
    var formdata = $("#AddParentCategory").serialize();


    // debugger;

    $.ajax(
        {
            type: "POST",
            url: "/ParentCategory/UpdateParentCategory",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetParentCategory();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}

function DeleteParentCategory(id) {

    confirm("Are you sure you want want to delete this ParentCategory");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/ParentCategory/DeleteParentCategory?Id=" + row_id + "",
        success: function (data) {
            GetParentCategory();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}

