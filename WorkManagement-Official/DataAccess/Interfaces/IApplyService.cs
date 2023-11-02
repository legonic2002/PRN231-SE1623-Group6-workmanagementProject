using Entities.EntitiesDto;

namespace DataAccess.Interfaces
{
    public interface IApplyService
    {
        Task<CustomResponse> GetListAppliedAndCaredJob(int accountKey);

        Task<CustomResponse> CancelCaredJob(int aajcKey);

        Task<CustomResponse> GetListAppliedUserForJob(int postKey);
        Task<CustomResponse> AppliedJob(AppliedUserDto appliedUser);
    }
}
