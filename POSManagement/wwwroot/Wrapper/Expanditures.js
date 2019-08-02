function Expanditures() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateExpanditures").hide();
    $("#InsertExpanditures").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Refno").val("");
    $("#Whatfor").val("");
    $("#Amount").val("");
    $("#Notes").val("");
    $("#Returnable").val("No");
    $("#cat").val("Halib");
    //$("#Returnable option[value='No']").prop('selected', true);
    //$("#cat option[value='Halib']").prop('selected', true);
}


function AddExpanditures() {
    //  alert("Add LineItem");
    debugger;
    var formdata = $("#AddExpanditures").serialize();
    var cat = $("#cat").val();
    $.ajax(
        {
            type: "POST",
            url: "/Expanditures/AddExpanditures?cat=" + cat,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                clear();
                GetExpanditures();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetExpanditures();

});
window.GetExpanditures= function () {
    
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetExpanditures tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Expanditures/GetExpanditures",
        success: function (result) {
            // console.log(result);
            //  debugger;
            var row = '';
            $("#GetExpanditures").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.whatfor + "</td><td>" + v.categorys.name + "</td><td>" + v.amount + "</td><td>" + v.createdOn + "</td><td>" + 
                    '<a href="#" onclick="FindExpanditures(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteExpanditures(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetExpanditures").append(row);
           
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindExpanditures(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertExpanditures").hide();
    $("#UpdateExpanditures").show();
    $.ajax({

        url: "/Expanditures/FindExpanditures",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Refno").val(data.refno);
            $("#Whatfor").val(data.whatfor);
            $("#Amount").val(data.amount);
            $("#Notes").val(data.notes);
           
         
            $("#Returnable option[value='" + data.returnable + "']").prop('selected', true);
            $("#cat option[value='" + data.categorys.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function UpdateExpandituress() {
    alert("Update Item");
      debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#UpdateExpandituress").serialize();
    var cat = $("#cat").val();
    $.ajax({
        type: "Post",
        url: "/Expanditures/UpdateExpanditures?cat=" + cat,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetExpanditures();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteExpanditures(id) {

    confirm("Are you sure you want want to delete this Expanditures");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Expanditures/DeleteExpanditures?Id=" + row_id + "",
        success: function (data) {
            GetExpanditures();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
