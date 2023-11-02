using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess;

namespace WorkManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvfilesController : ControllerBase
    {
        private readonly ICvFileService _cvFileService;

        public CvfilesController(ICvFileService cvFileService)
        {
            _cvFileService = cvFileService;
        }

        [HttpGet("get-cv-source-by-account/{accountKey}")]
        public async Task<CustomResponse> GetCvFileSourceByAccount(int accountKey)
        {
            return await _cvFileService.GetCvFileSourceByAccount(accountKey);
        }

        [HttpGet("get-cv-source/{cvFileKey}")]
        public async Task<CustomResponse> GetCvFileSource(int cvFileKey)
        {
            return await _cvFileService.GetCvFileSource(cvFileKey);
        }

        [HttpPut("{cvFileKey}/{accountKey}")]
        public async Task<CustomResponse> PutCvfile(IFormFile cvFile, int cvFileKey, int accountKey)
        {
            return await _cvFileService.UpdateCvFile(cvFileKey, accountKey, cvFile);
        }

        [HttpPost("{accountKey}")]
        public async Task<CustomResponse> PostCvfile(IFormFile cvFile, int accountKey)
        {
            return await _cvFileService.AddCvFile(accountKey, cvFile);
        }

        [HttpDelete("{cvFileKey}/{accountKey}")]
        public async Task<CustomResponse> DeleteCvfile(int cvFileKey, int accountKey)
        {
            return await _cvFileService.DeleteCvFile(cvFileKey, accountKey);
        }
    }
}
