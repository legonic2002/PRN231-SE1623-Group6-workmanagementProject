using DataAccess;
using DataAccess.Interfaces;
using Entities.EntitiesDto;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<CustomResponse> GetCompanies()
        {
            return await _companyService.GetCompanies();
        }

        [HttpGet("{companyKey}")]
        public async Task<CustomResponse> GetCompany(int companyKey)
        {
            return await _companyService.GetCompany(companyKey);
        }

        [HttpPut("{companyKey}")]
        public async Task<CustomResponse> PutCompany(int companyKey, CompanyDto company)
        {
            return await _companyService.UpdateCompany(companyKey, company);
        }

        [HttpPost]
        public async Task<CustomResponse> PostCompany(CompanyDto company)
        {
            return await _companyService.AddCompany(company);
        }

        [HttpDelete("{companyKey}")]
        public async Task<CustomResponse> DeleteCompany(int companyKey)
        {
            return await _companyService.DeleteCompany(companyKey);
        }

    }
}
