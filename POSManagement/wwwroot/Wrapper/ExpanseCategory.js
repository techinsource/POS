function ExpanseCategory() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateExpanseCategory").hide();
    $("#InsertExpanseCategory").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Details").val("");
    $("#Status").val("Active");
    $("#Order").val("0");
    $("#ParentCategorys").val("Office Boy");
    $("#Parentcat").val("Select ParentCategory");


}


function AddExpanseCategory() {
    //$("#Name").on("input", function () {
    //    // alert("check");
    //    $("#Slug").val($("#Name").val());
    //});
   
    //  alert("Add LineItem");
    debugger;
    var formdata = $("#AddExpanseCategory").serialize();
    var Parentcat = $("#Parentcat").val();
    $.ajax(
        {
            type: "POST",
            url: "/ExpanseCategory/AddExpanseCategory?Parentcat=" + Parentcat,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetExpanseCategory();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetExpanseCategory();

});
window.GetExpanseCategory = function () {
   // alert("Get");
    //debugger;
    $("#Name").on("keyup", function () {
       // alert("heloo");
         $("#Slug").val($("#Name").val());
    });
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetExpanseCategory tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/ExpanseCategory/GetExpanseCategory",
        success: function (result) {
            //  console.log(result);
            // debugger;
            var row = '';
            $("#GetExpanseCategory").html('');

            $.each(result, function (i, v) {
                
                row += "<tr><td>" + v.name + "</td><td>" + v.order + "</td><td>" + v.status + "</td><td>" + v.createdOn + "</td><td>" + 
                    '<a href="#" onclick="FindExpanseCategory(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteExpanseCategory(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetExpanseCategory").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindExpanseCategory(id) {
   // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertExpanseCategory").hide();
    $("#UpdateExpanseCategory").show();
    $.ajax({

        url: "/ExpanseCategory/FindExpanseCategory",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {
           
            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);
            $("#Details").val(data.details);
            $("#Status").val(data.status);
            $("#Order").val(data.order);
            $("#Slug").val(data.name);
            $("#Status option[value='" + data.status + "']").prop('selected', true);
           // $("#ParentCategorys option[value='" + data.parentCategorys.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function UpdateExpanseCategorys() {
    alert();
    var formdata = $("#AddExpanseCategory").serialize();
    var Parentcat = $("#Parentcat").val();
    $.ajax({
        type: "Post",
        url: "/ExpanseCategory/UpdateExpanseCategory?Parentcat=" + Parentcat,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetExpanseCategory();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteExpanseCategory(id) {
   // alert();
    confirm("Are you sure you want want to delete this ExpanseCategorys");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/ExpanseCategory/DeleteExpanseCategory?Id=" + row_id + "",
        success: function (data) {
            GetExpanseCategory();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
