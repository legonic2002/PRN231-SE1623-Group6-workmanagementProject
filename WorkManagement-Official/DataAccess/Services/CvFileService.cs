using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace DataAccess.Services
{
    public class CvFileService : ICvFileService
    {
        private readonly ICvFileRepository _cvFileRepository;

        public CvFileService(ICvFileRepository cvFileRepository)
        {
            _cvFileRepository = cvFileRepository;
        }

        public async Task<CustomResponse> AddCvFile(int accountKey, IFormFile cvFile)
        {
            var result = await _cvFileRepository.AddCvFile(accountKey, cvFile);
            if (result !=null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Add cv successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Add cv failed.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> DeleteCvFile(int cvFileKey, int accountKey)
        {
            var result = await _cvFileRepository.DeleteCvFile(cvFileKey, accountKey);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Message = "Delete cv successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Message = "Delete cv failed.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetCvFileSource(int cvFileKey)
        {
            var result = await _cvFileRepository.GetCvFileSource(cvFileKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Get cv successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Get cv failed.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetCvFileSourceByAccount(int accountKey)
        {
            var result = await _cvFileRepository.GetCvFileSourceByAccount(accountKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Get cv successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Get cv failed.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> UpdateCvFile(int cvFileKey, int accountKey, IFormFile cvFile)
        {
            var result = await _cvFileRepository.UpdateCvFile(cvFileKey, accountKey, cvFile);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Message = "Update cv successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Message = "Update cv failed.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }
    }
}
