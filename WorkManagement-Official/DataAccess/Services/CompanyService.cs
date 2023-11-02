using DataAccess.Interfaces;
using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CustomResponse> AddCompany(CompanyDto company)
        {
            var result = await _companyRepository.AddCompany(company);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Company added successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Company not added.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> DeleteCompany(int companyKey)
        {
            var result = await _companyRepository.DeleteCompany(companyKey);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Data = null,
                    Message = "Company deleted successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Company not deleted.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetCompanies()
        {
            var result = await _companyRepository.GetCompanies();
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Companies found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Companies not found.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetCompany(int companyKey)
        {
            var result = await _companyRepository.GetCompany(companyKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Company found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Company not found.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> UpdateCompany(int companyKey, CompanyDto company)
        {
            var result = await _companyRepository.UpdateCompany(companyKey, company);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Company updated successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Company not updated.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }
    }
}
