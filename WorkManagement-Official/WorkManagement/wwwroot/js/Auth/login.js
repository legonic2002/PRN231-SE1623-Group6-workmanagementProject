$(document).ready(function () {
  // catch event onclick button login
  $("#btn-login").click(function () {
    // get value from input
    var email = $("#email").val();
    var password = $("#password").val();
    axios({
      method: "post",
      url: "/api/Accounts/login",
      data: {
        email: email,
        password: password,
      },
    }).then((response) => {
      var data = response.data;
      if (data.statusCode == 400) {
        Swal.fire({
          icon: "error",
          title: "Login Failed !",
          text: "Please enter your correct email & password",
        }).then();
      } else {
        Swal.fire({
          text: "Login Successfully!",
          icon: "success",
          buttonsStyling: false,
          confirmButtonText: "Ok, got it!",
          customClass: {
            confirmButton: "btn",
          },
        }).then((result) => {
          localStorage.setItem("accountKey", data.data.accountKey);
          window.location.href = "/home";
        });
      }
    });
  });
});
