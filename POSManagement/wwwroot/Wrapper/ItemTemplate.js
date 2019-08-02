function ItemTemplate() {
    // alert();
    // $("#modal-form").modal("");
    $("#UpdateItemTemplate").hide();
    $("#InsertItemTemplate").show();
    clear();

}
function clear() {
    $("#Id").val("");
    $("#Name").val("");
    $("#Code").val("");
    $("#Sortorder").val("");
    

}


function AddItemTemplate() {
    //  alert("Add LineItem");
    debugger;
    var formdata = $("#AddItemTemplate").serialize();
    var litm = $("#litm").val()
    $.ajax(
        {
            type: "POST",
            url: "/ItemTemplate/AddItemTemplate?litm=" + litm,

            data: formdata,

            success: function (data) {

                $("#modal-form").modal("hide");
                GetItemTemplate();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



$(window).load(function () {
    GetItemTemplate();

});
window.GetItemTemplate = function () {
    // alert("Get");
    //debugger;
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetItemTemplate tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
    $.ajax({
        type: "GET",
        url: "/ItemTemplate/GetItemTemplate",
        success: function (result) {
            //  console.log(result);
            // debugger;
            var row = '';
            $("#GetItemTemplate").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.lineItemDefinition.name + "</td><td>" + v.sortorder + "</td><td>" + 
                    '<a href="#" onclick="FindItemTemplate(this)" data-id="' + v.id + '">Edit</a> | <a href="#" onclick="DeleteItemTemplate(this)" data-id="' + v.id +
                    '">Delete</a>' + "</td></tr>";


            });
            $("#GetItemTemplate").append(row);
            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
}

function FindItemTemplate(id) {
   // alert("Find Category");
    // debugger;
    var row_id = $(id).data('id');
    $("#Id").val(row_id);
    var formdata = { Id: row_id };
    $("#InsertItemTemplate").hide();
    $("#UpdateItemTemplate").show();
    $.ajax({

        url: "/ItemTemplate/FindItemTemplate",
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
           
            $("#litm option[value='" + data.lineItemDefinition.id + "']").prop('selected', true);
            $("#modal-form").modal("show");
        },
        error: function (data) {
            alertify.error(data);
        }
    });
}

function ItemTemplateUpdate() {
    // alert("Update Item");
    // debugger;
    //var formdata = $("#RoleShow").serialize();
    var formdata = $("#AddItemTemplate").serialize();
    var litm = $("#litm").val()
    $.ajax({
        type: "Post",
        url: "/ItemTemplate/UpdateItemTemplate?litm=" + litm,
        data: formdata,
        success: function (data) {
            $("#modal-form").modal("hide");
            GetItemTemplate();

        },

        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}


function DeleteItemTemplate(id) {

    confirm("Are you sure you want want to delete this ItemTemplate");
    debugger;
    var row_id = $(id).data('id');
    $.ajax({
        type: "Post",
        url: "/ItemTemplate/DeleteIItemTemplate?Id=" + row_id + "",
        success: function (data) {
            GetItemTemplate();
        },
        error: function (xhr) {
            alertify.error(xhr.responseText);
        }
    });
}
