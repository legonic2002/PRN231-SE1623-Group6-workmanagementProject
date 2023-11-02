$(document).ready(function () {
  // catch event onclick button login
  const doFilter = () => {
    let title = $("#title").val();
    let cate = $("#cate").val();
    let locaion = $("#location").val();
    let exp = $("#exp").val();
    let sort = $("#sort").val();
    console.log(title + cate + " " + locaion + " " + exp + " " + sort);

    let filterUrl =
      "/api/Posts?search=" +
      title +
      "&jobFieldFilter=" +
      cate +
      "&locationFilter=" +
      locaion +
      "&experienceFilter=" +
      exp +
      "&sort=" +
      sort;

    axios({
      method: "get",
      url: filterUrl,
    }).then((response) => {
      $("#post_list").html("");
      let newHtml = "";
      response.data.data.forEach((item) => {
        newHtml += `
                <div class="single-job-items mb-30">
                    <div class="job-items">
                        <div class="company-img">
                            <a href="#"><img src="/assets/img/icon/${item.companyDto.imageUrl}" alt=""></a>
                        </div>
                        <div class="job-tittle job-tittle2">
                            <a href="/job/post/${item.postKey}">
                                <h4>${item.title}</h4>
                            </a>
                            <ul>
                                <li>${item.companyDto.name}</li>
                                <li><i class="fas fa-map-marker-alt"></i>${item.companyDto.location}</li>
                                <li>$${item.salaryFrom} - $${item.salaryTo}</li>
                            </ul>
                        </div>
                    </div>
                    <div class="items-link items-link2 f-right">
                        <a href="/job/post/${item.postKey}">${item.workType}</a>
                    </div>
                </div>
               `;
          $("#post_list").html(newHtml);
      });
        $("#size").html(response.data.data.length + " Jobs found")
    });
  };

    $("#title").on("keyup", doFilter);
  $("#btn_filter").on("click", doFilter);
});
