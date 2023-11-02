using Microsoft.AspNetCore.Http;

namespace DataAccess.Interfaces
{
    public interface ICvFileService
    {
        Task<CustomResponse> GetCvFileSourceByAccount(int accountKey);
        Task<CustomResponse> GetCvFileSource(int cvFileKey);
        Task<CustomResponse> AddCvFile(int accountKey, IFormFile cvFile);
        Task<CustomResponse> UpdateCvFile(int cvFileKey, int accountKey, IFormFile cvFile);
        Task<CustomResponse> DeleteCvFile(int cvFileKey, int accountKey);
    }
}
