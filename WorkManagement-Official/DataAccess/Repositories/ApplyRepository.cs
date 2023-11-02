using AutoMapper;
using DataAccess.Entities;
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
    public class ApplyRepository : IApplyRepository
    {
        private readonly WorkManagementStableContext _context;
        private readonly IMapper _mapper;

        public ApplyRepository(WorkManagementStableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CancelCaredJob(int aajcKey)
        {
            try
            {
                var appliedAndCared = await _context.AppliedAndCareds.FindAsync(aajcKey);
                if (appliedAndCared != null && appliedAndCared.Status == "Cared")
                {
                    _context.AppliedAndCareds.Remove(appliedAndCared);
                }
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public async Task<IEnumerable<AppliedAndCaredDto>?> GetListAppliedAndCaredJob(int accountKey)
        {
            try
            {
                var listAppliedAndCared = await _context.AppliedAndCareds
                    .Where(AppliedAndCared => AppliedAndCared.AccountKey == accountKey)
                    .ToListAsync();
                return listAppliedAndCared
                    .Select(appliedAndCared => _mapper.Map<AppliedAndCaredDto>(appliedAndCared));
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<AppliedUserDto>?> GetListAppliedUserForJob(int postKey)
        {
            try
            {
                var listAppliedUserForJob = await _context.AppliedUsers.AsNoTracking()
                    .Where(AppliedUsers => AppliedUsers.PostKey == postKey)
                    .ToListAsync();
                return listAppliedUserForJob
                    .Select(appliedUser => _mapper.Map<AppliedUserDto>(appliedUser));
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> AppliedJob(AppliedUserDto appliedUser)
        {
            try
            {
                var appliedAndCared = new AppliedAndCaredDto
                {
                    AccountKey = appliedUser.AccountKey,
                    PostKey = appliedUser.PostKey,
                    Status = "Applied"
                };
                var appliedUserEntity = _mapper.Map<AppliedUser>(appliedUser);
                await _context.AppliedUsers.AddAsync(appliedUserEntity);
                if (await _context.SaveChangesAsync() > 0)
                {
                    var appliedAndCaredEntity = _mapper.Map<AppliedAndCared>(appliedAndCared);
                    await _context.AppliedAndCareds.AddAsync(appliedAndCaredEntity);
                    return await _context.SaveChangesAsync();
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
