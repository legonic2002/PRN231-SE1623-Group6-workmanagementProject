$(document).ready(function () {
  const btnToggleChangePassword = document.querySelector(
    "#btn-toggle-change-password"
  );
  const newPassword = document.querySelector("#newPass");
  const confirmPassword = document.querySelector("#cfPass");
  const formUpdateInfor = document.querySelector("#form-update-infor");

  $("#btn_profile").click(function (e) {
    e.preventDefault();
    // get value from input
    var accountKey = localStorage.getItem("accountKey");
    var first_name = $("#firstName").val();
    var last_name = $("#lastName").val();
    var email = $("#email").val();

    axios({
      method: "put",
      url: "/api/Accounts",
      data: {
        accountKey: accountKey,
        firstName: first_name,
        lastName: last_name,
        email: email,
        oldPassword: "",
        newPassword: "",
        confirmNewPassword: "",
      },
    }).then((response) => {
      var data = response.data;
      if (data.statusCode == 400) {
        Swal.fire({
          icon: "error",
          title: "Update Failed !",
          text: "Please enter your correct email & password",
        }).then();
      } else {
        Swal.fire({
          text: "Update Successfully!",
          icon: "success",
          buttonsStyling: false,
          confirmButtonText: "Ok, got it!",
          customClass: {
            confirmButton: "btn",
          },
        }).then((result) => {
          axios({
            method: "post",
            url: "/api/Accounts/reset",
          }).then((response) => {
            location.reload();
          });
        });
      }
    });
  });
  $("#btn_pass").click(function (e) {
    e.preventDefault();
    // get value from input
    var accountKey = localStorage.getItem("accountKey");
    var new_pass = newPassword.value;
    var confirm_pass = confirmPassword.value;
    var old_Password = $("#oldPass").val();
    axios({
      method: "put",
      url: "/api/Accounts/pass",
      data: {
        accountKey: accountKey,
        oldPassword: old_Password,
        newPassword: new_pass,
        confirmNewPassword: confirm_pass,
      },
    }).then((response) => {
      var data = response.data;
      if (data.statusCode == 400) {
        Swal.fire({
          icon: "error",
          title: "Update Failed !",
          text: "Please check your password !",
        }).then();
      } else {
        Swal.fire({
          text: "Update Successfully!",
          icon: "success",
          buttonsStyling: false,
          confirmButtonText: "Ok, got it!",
          customClass: {
            confirmButton: "btn",
          },
        }).then((result) => {
          location.reload();
        });
      }
    });
  });
});
