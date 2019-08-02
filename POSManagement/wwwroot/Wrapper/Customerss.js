function Customerss() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateCustomerss").hide();
    $("#InsertCustomerss").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Creditbalance").val("");
    $("#Phone").val("");
    $("#Email").val("");
    $("#Age").val("");
    $("#Address").val("");
    $("#City").val("");
    $("#Country").val("Pakistan");
    $("#Order").val("");
   // $("#IsActive").val("Active");
    $("#Sex").val("Male");
}


function AddCustomerss() {
      //alert("Add Customer");
    // debugger;
    var formdata = $("#AddCustomerss").serialize();
    $.ajax(
        {
            type: "POST",
            url: "/Customerss/AddCustomerss",

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetCustomerss();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetCustomerss();

});
window.GetCustomerss = function () {
    //alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetCustomerss tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/Customerss/GetCustomerss",
        success: function (result) {
            // console.log(result);
            //  debugger;
            var row = '';
            $("#GetCustomerss").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.name + "</td><td>" + v.phone + "</td><td>" + v.sex + "</td><td>" + v.creditbalance + "</td><td>" + 
                    '<a href="#" onclick="FindCustomerss(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteCustomerss(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetCustomerss").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindCustomerss(id) {
    // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertCustomerss").hide();
    $("#UpdateCustomerss").show();
    $.ajax({

        url: "/Customerss/FindCustomerss",
        type: "Get",
        data: formdata,
        dataType: "Json",

        success: function (data) {

            //// debugger;
            //// console.log(data);
            $("#Id").val(data.id);
            $("#Name").val(data.name);

            $("#Creditbalance").val(data.creditbalance);
            $("#Phone").val(data.phone);
            $("#Email").val(data.email);
            $("#Age").val(data.age);
            $("#Address").val(data.address);
            $("#City").val(data.city);
            
            $("#Order").val(data.order);
            $("#Sex option[value='" + data.sex + "']").prop('selected', true); 
            $("#IsActive option[value='" + data.isActive + "']").prop('selected', true);
            $("#Country option[value='" + data.country + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function CustomerssUpdate() {
    //alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddCustomerss").serialize();
    
    $.ajax({
        type: "Post",
        url: "/Customerss/UpdateCustomerss",
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetCustomerss();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteCustomerss(id) {

    confirm("Are you sure you want want to delete this Customerss");
    //debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/Customerss/DeleteCustomerss?Id=" + row_id + "",
        success: function (data) {
            GetCustomerss();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
