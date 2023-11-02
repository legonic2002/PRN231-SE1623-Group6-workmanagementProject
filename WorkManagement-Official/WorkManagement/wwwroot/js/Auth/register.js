document
    .querySelector("#reg-from")
    .addEventListener("submit", function (e) {
        e.preventDefault();
        //check form empty
        if (e.target.elements["password"].value !== e.target.elements["re-password"].value) {
            toastr.error("Password not Match !");
            return;
        }
        if (
            e.target.elements["fname"].value === "" ||
            e.target.elements["lname"].value === "" ||
            e.target.elements["email"].value === "" ||
            e.target.elements["password"].value === "" ||
            e.target.elements["re-password"].value === ""
        ) {
            toastr.error("Please fill in all fields!");
            return;
        }

        axios({
            method: "post",
            url: "/api/Accounts",
            data: {
                firstName: e.target.elements["fname"].value,
                lastName: e.target.elements["lname"].value,
                email: e.target.elements["email"].value,
                password: e.target.elements["password"].value,
                confirmPassword: e.target.elements["re-password"].value,
                role: "USER"
            },
        }).then((response) => {
            if (response.data.statusCode == 400) {
                swalFailed("Account already exsist!");
                return;
            }
            swalSuccess("Registration Successfully!").then(t => {
                window.location.href = "/auth/login";
            });
        }).catch((error) => {
            swalFailed("Registration Failed!");
        });
    });