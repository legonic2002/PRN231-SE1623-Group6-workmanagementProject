using Microsoft.AspNetCore.Mvc;
using DataAccess;
using DataAccess.Interfaces;
using Entities.EntitiesDto;

namespace WorkManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {
        private readonly IApplyService _applyService;

        public ApplyController(IApplyService applyService)
        {
            _applyService = applyService;
        }

        [HttpGet("get-list-applied-and-cared-job")]
        public async Task<CustomResponse> GetListAppliedAndCared()
        {
            return await _applyService.GetListAppliedAndCaredJob(1);
        }

        [HttpDelete("cancel-applied-and-cared-job")]
        public async Task<CustomResponse> CancelAppliedAndCared(int aajcKey)
        {
            return await _applyService.CancelCaredJob(aajcKey);
        }

        [HttpGet("get-list-applied-user-for-job/{postKey}")]
        public async Task<CustomResponse> GetListAppliedUserForJob(int postKey)
        {
            return await _applyService.GetListAppliedUserForJob(postKey);
        }

        [HttpPost("apply-job")]
        public async Task<CustomResponse> ApplyJob(AppliedUserDto appliedUser)
        {
            return await _applyService.AppliedJob(appliedUser);
        }
    }
}
