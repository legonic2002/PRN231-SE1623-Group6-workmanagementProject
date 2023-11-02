using Entities.EntitiesDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICvFileRepository
    {
        Task<IEnumerable<CvfileDto>?> GetCvFileSourceByAccount(int accountKey);
        Task<string> GetCvFileSource(int cvFileKey);
        Task<CvfileDto?> AddCvFile(int accountKey, IFormFile cvFile);
        Task<int> UpdateCvFile(int cvFileKey, int accountKey, IFormFile cvFile);
        Task<int> DeleteCvFile(int cvFileKey, int accountKey);
    }
}
