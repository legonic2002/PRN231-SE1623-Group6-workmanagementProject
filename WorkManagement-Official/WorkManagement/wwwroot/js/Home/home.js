$(document).ready(function () {
  // catch event onclick button login
    $(document).ready(function () {
        $("#btn_search").click(function (e) {
            e.preventDefault();
            var search = $("#search_key").val();
            var location = $("#job_location").val();
            console.log("/job/list?title=" + search + "&location=" + location);
            window.location.href = "/job/list?title=" + search + "&location=" + location;
        })
    })
});
