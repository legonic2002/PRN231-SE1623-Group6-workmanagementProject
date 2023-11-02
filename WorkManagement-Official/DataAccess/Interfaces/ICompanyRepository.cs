using DataAccess.Entities;
using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICompanyRepository
    {
        Task<CompanyDto?> AddCompany(CompanyDto company);
        Task<CompanyDto?> UpdateCompany(int companyKey, CompanyDto company);
        Task<int> DeleteCompany(int companyKey);
        Task<CompanyDto?> GetCompany(int companyKey);
        Task<IEnumerable<CompanyDto>?> GetCompanies();
    }
}
