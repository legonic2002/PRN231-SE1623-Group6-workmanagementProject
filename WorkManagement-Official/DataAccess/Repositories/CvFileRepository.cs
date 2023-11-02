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
    public class CvFileRepository : ICvFileRepository
    {
        private readonly WorkManagementStableContext _context;
        private readonly IMapper _mapper;

        public CvFileRepository(WorkManagementStableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CvfileDto?> AddCvFile(int accountKey, IFormFile cvFile)
        {
            try
            {
                var cvFileDto = new CvfileDto
                {
                    AccountKey = accountKey,
                    CvfileSource = await HandleFile.WriteFile(cvFile)
                };
                var cvFileEntity = _mapper.Map<Cvfile>(cvFileDto);
                await _context.Cvfiles.AddAsync(cvFileEntity);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return _mapper.Map<CvfileDto>(cvFileEntity);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> DeleteCvFile(int cvFileKey, int accountKey)
        {
            try
            {
                var cvFileEntity = _context.Cvfiles.FirstOrDefault(x => x.CvfileKey == cvFileKey && x.AccountKey == accountKey);
                if (cvFileEntity == null)
                {
                    return -1;
                }
                _context.Cvfiles.Remove(cvFileEntity);
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public async Task<string> GetCvFileSource(int cvFileKey)
        {
            try
            {
                var cvFileEntity = await _context.Cvfiles.FindAsync(cvFileKey);
                if (cvFileEntity == null)
                {
                    return "";
                }
                return cvFileEntity.CvfileSource;
            }
            catch
            {
                return "";
            }
        }

        public async Task<IEnumerable<CvfileDto>?> GetCvFileSourceByAccount(int accountKey)
        {
            try
            {
                var listCvFile = await _context.Cvfiles.Where(x => x.AccountKey == accountKey).ToListAsync();
                return listCvFile.Select(x => _mapper.Map<CvfileDto>(x));
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> UpdateCvFile(int cvFileKey, int accountKey, IFormFile cvFile)
        {
            try
            {
                var oldCvFileEntity = _context.Cvfiles.FirstOrDefault(x => x.CvfileKey == cvFileKey && x.AccountKey == accountKey);
                if (oldCvFileEntity == null)
                {
                    return -1;
                }
                var cvFileDto = new CvfileDto
                {
                    CvfileKey = cvFileKey,
                    AccountKey = accountKey,
                    CvfileSource = await HandleFile.WriteFile(cvFile)
                };
                var cvFileEntity = _mapper.Map<Cvfile>(cvFileDto);
                cvFileEntity.CvfileKey = cvFileKey;
                _context.Entry(oldCvFileEntity).CurrentValues.SetValues(cvFileEntity);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    HandleFile.DeleteFile(oldCvFileEntity.CvfileSource);
                    return result;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
