$(document).ready(function () {
    // catch event onclick button login
    const doFilter = () => {
        console("doFilter");
    };

    $("#btn_pass").click(function (e) {
        e.preventDefault();
        // get value from input
        axios({
            method: "post",
            url: "/api/Posts",
            data: {
                postKey: 0,
                title: $("#title").val(),
                companyKey: $("#companyKey").val(),
                toTime: $("#toTime").val(),
                salaryType: "string",
                salary: $("#salaryTo").val(),
                salaryFrom: $("#salaryFrom").val(),
                salaryTo: $("#salaryTo").val(),
                workType: $("#workType").val(),
                sex: "Male",
                candidates: $("#candidates").val(),
                level: "string",
                experienceType: "string",
                experience: 1,
                experienceFrom: $("#experienceFrom").val(),
                experienceTo: $("#experienceTo").val(),
                description: $("#description").val(),
                requiredCandicate: $("#requiredCandicate").val(),
                benefits: "string",
                jobField: $("#jobField").val(),
                companyDto: {
                    companyKey: 0,
                    name: "string",
                    description: "string",
                    imageUrl: "string",
                    logoUrl: "string",
                    location: "string",
                    workField: "string"
                }
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
