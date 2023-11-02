$(document).ready(function () {
    // catch event onclick button login

    axios({
        method: "get",
        url: "/api/Apply/get-list-applied-and-cared-job",
    }).then((response) => {
        $("#a_list").html("");
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
    });
});
