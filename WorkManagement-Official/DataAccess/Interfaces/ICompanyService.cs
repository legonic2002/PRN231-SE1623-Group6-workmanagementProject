using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICompanyService
    {
        Task<CustomResponse> AddCompany(CompanyDto company);
        Task<CustomResponse> UpdateCompany(int companyKey, CompanyDto company);
        Task<CustomResponse> DeleteCompany(int companyKey);
        Task<CustomResponse> GetCompany(int companyKey);
        Task<CustomResponse> GetCompanies();
    }
}
