function AddChangeRetailPrice() {
    //  alert("Add LineItem");
    // debugger;
    var formdata = $("#AddChangeRetailPrice").serialize();
    var litm = $("#litm").val()
    $.ajax(
        {
            type: "POST",
            url: "/ChangeRetailPrice/AddChageRetailPrice",

            data: formdata,

            success: function (data) {

                
                GetChageRetailPrice();
            },
            error: function (data) {
                alertify.error(data);
            }
        });

}



 function NewPrice () {
    alert("Get");
   debugger;
    var value = $("#value").val(),
    $("#myInput").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $("#GetChangenRetailPrice tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });

      


    });
    $.ajax({
        url: "/ChangeRetailPrice/GetChageRetailPrice?value=" + value,
        type: "GET",
       
       
      //url: "/ProductPricing/GetProductPricing?Category=" + Category,
        success: function (result) {
            
            debugger;
            //var data = result.result;
            //console.log(data);

            var row = '';
            $("#GetChangenRetailPrice").html('');

            $.each(result, function (i, v) {
                row += "<tr><td>" + v.code + "</td><td>" + v.name + "</td><td>" + v.cost_Price + "</td><td>" + v.retail_Price + "</td><td>" + v.newPrice + "</td><td>";


            });
            $("#GetChangenRetailPrice").append(row);


            //hide_waitMe("#collapseOne");
            // LoadUserinDropdownfromNav();
        },
        error: function (result) {
            alertify.error(result.responseText);

        }
    });
} 


