using Entities.EntitiesDto;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Interfaces
{
    public interface IApplyRepository
    {
        Task<IEnumerable<AppliedUserDto>?> GetListAppliedUserForJob(int postKey);

        Task<IEnumerable<AppliedAndCaredDto>?> GetListAppliedAndCaredJob(int accountKey);

        Task<int> CancelCaredJob(int aajcKey);

        Task<int> AppliedJob(AppliedUserDto appliedUser);
    }
}
