$(document).ready(function () {
    // catch event onclick button login
    const doFilter = () => {
        console("doFilter");
    };

    $("#btn_add").click(function (e) {
        e.preventDefault();
        // get value from input
        axios({
            method: "post",
            url: "/api/Companies",
            data: {
                companyKey: 0,
                name: $("#name").val(),
                description: $("#description").val(),
                imageUrl: "job-list1.png",
                logoUrl: "job-list1.png",
                location: $("#location").val(),
                workField: "IT",
                imageFile: null,
                logoFile: null
            },
        }).then((response) => {
            var data = response.data;
            console.log(data)
            if (data.statusCode == 400) {
                Swal.fire({
                    icon: "error",
                    title: "Add Failed !",
                    text: "Please check your password !",
                }).then();
            } else {
                Swal.fire({
                    text: "Add Successfully!",
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
