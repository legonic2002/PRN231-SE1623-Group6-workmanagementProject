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
    public class ApplyService : IApplyService
    {
        private readonly IApplyRepository _applyRepository;

        public ApplyService(IApplyRepository applyRepository)
        {
            _applyRepository = applyRepository;
        }

        public async Task<CustomResponse> AppliedJob(AppliedUserDto appliedUser)
        {
            var result =await _applyRepository.AppliedJob(appliedUser);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Message = "Applied job successfully!",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Message = "Applied job failed!",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> CancelCaredJob(int aajcKey)
        {
            var result = await _applyRepository.CancelCaredJob(aajcKey);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Cancel applied and cared job successfully!",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Cancel applied and cared job failed!",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetListAppliedAndCaredJob(int accountKey)
        {
            var result = await _applyRepository.GetListAppliedAndCaredJob(accountKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Get list applied and cared job successfully!",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Get list applied and cared job failed!",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetListAppliedUserForJob(int postKey)
        {
            var result = await _applyRepository.GetListAppliedUserForJob(postKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Get list applied user for job successfully!",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = result,
                Message = "Get list applied user for job failed!",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }
    }
}
