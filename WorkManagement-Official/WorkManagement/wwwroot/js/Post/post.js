$(document).ready(function () {
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
                    url: "/api/Posts/" + id,
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
                            title: 'Posts has been deleted',
                            showConfirmButton: false,
                            timer: 1500
                        }).then(() => {
                            window.location.href= "/job/list"
                        })
                    }
                });
            }
        });
    }
    document.getElementsByClassName("mybtn")[0].addEventListener("click", () => {
        const elementId = event.target.id;
/*        console.log(elementId.replace("delete_", ""));*/
        Delete(elementId.replace("delete_", ""));
    });
});
