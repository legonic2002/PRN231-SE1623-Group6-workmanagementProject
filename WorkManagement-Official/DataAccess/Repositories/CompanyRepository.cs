using AutoMapper;
using DataAccess.Entities;
using DataAccess.Helpers;
using DataAccess.Interfaces;
using Entities.EntitiesDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly WorkManagementStableContext _context;
        private readonly IMapper _mapper;

        public CompanyRepository(WorkManagementStableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompanyDto?> AddCompany(CompanyDto company)
        {
            try
            {
                var companyAdded = _mapper.Map<Company>(company);
                companyAdded.ImageUrl =await HandleFile.WriteFile(company.ImageFile!);
                companyAdded.LogoUrl = await HandleFile.WriteFile(company.LogoFile!);
                await _context.Companies.AddAsync(companyAdded);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<CompanyDto>(companyAdded);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> DeleteCompany(int companyKey)
        {
            try
            {
                var company = await _context.Companies.FindAsync(companyKey);
                if (company != null)
                {
                    _context.Companies.Remove(company);
                }
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public async Task<IEnumerable<CompanyDto>?> GetCompanies()
        {
            try
            {
                var companies = await _context.Companies.ToListAsync();
                return companies.Select(company => _mapper.Map<CompanyDto>(company));
            }
            catch
            {
                return null;
            }
        }

        public async Task<CompanyDto?> GetCompany(int companyKey)
        {
            try
            {
                var company = await _context.Companies.FindAsync(companyKey);
                return _mapper.Map<CompanyDto>(company);
            }
            catch
            {
                return null;
            }
        }

        public async Task<CompanyDto?> UpdateCompany(int companyKey, CompanyDto company)
        {
            try
            {
                var oldCompany = await _context.Companies.FindAsync(companyKey);
                if (oldCompany != null)
                {
                    oldCompany.Name = company.Name;
                    oldCompany.Location = company.Location;
                    oldCompany.Description = company.Description;
                    await _context.SaveChangesAsync();
                    return _mapper.Map<CompanyDto>(oldCompany);
                //    var companyUpdated = _mapper.Map<Company>(company);
                //    foreach (var property in companyUpdated.GetType().GetProperties())
                //    {
                //        if (property.GetValue(companyUpdated) == null || property.GetValue(companyUpdated)!.ToString()!.Trim().Equals(""))
                //        {
                //            property.SetValue(companyUpdated, property.GetValue(oldCompany));
                //        }
                //    }
                //    _context.Entry(oldCompany).CurrentValues.SetValues(company);
                //    if (_context.Entry(oldCompany).State == EntityState.Unchanged)
                //    {
                //        return company;
                //    }
                //    if(await _context.SaveChangesAsync() > 0)
                //    {
                //        return company;
                //    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
