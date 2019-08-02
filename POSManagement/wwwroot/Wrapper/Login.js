//function Login() {
//  //  alert("Login");
//   // debugger;
//    //var formdata = $("#UserLogin").serialize();
//    var formdata = $("#Login").serialize();
//    //$("#UpdateRole").hide();
//    // $("#saveRole").hide();

//    // debugger;

//    $.ajax({
        
//        type: "Post",
//        url: "/Login/UserLogin",
//        data: formdata,
//        success: function (result) {
//          //  alert("Success");
//            if (result !== null) {
//                window.location.replace("http://localhost:50185/Role/AddRole");
//            }
//            else {
//                window.location.replace("http://localhost:50185");
//            }
//            //else
//            //    window.location.href = "@Url.Action('Login','Home')";
//            //$("#modal-form").modal("hide");
//           // GetRoles();
//        },

//        error: function (xhr) {
//            window.location.replace("http://localhost:50185");
//          //  alert("Error");
//            alertify.error(xhr.responseText);
//        }
//    });
//}