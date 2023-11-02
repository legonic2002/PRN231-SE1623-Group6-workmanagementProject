$(document).ready(function () {
    const elements = document.getElementsByClassName("btn_delete");
    function Delete(id) {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!",
        }).then((result) => {
            if (result.isConfirmed) {
                axios({
                    method: "delete",
                    url: "/api/Accounts/" + id,
                    data: {},
                }).then((response) => {
                    var data = response.data;
                    if (data.statusCode == 400) {
                        Swal.fire({
                            icon: "error",
                            title: "Delete Failed !",
                            text: "Please enter your correct email & password",
                        }).then();
                    } else {
                        Swal.fire({
                            icon: 'success',
                            title: 'User has been deleted',
                            showConfirmButton: false,
                            timer: 1500
                        }).then(() => {
                            document.getElementById('ac-' + id).parentNode.parentNode.remove();
                        })
                    }
                });
            }
        });
    }
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener("click", () => {
            const elementId = event.target.id;
            Delete(elementId.replace("ac-", ""));
        });
    }
});
