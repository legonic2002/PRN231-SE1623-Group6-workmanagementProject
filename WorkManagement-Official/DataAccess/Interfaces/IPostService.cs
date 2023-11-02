using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPostService
    {
        Task<CustomResponse> GetPosts(string? search, string? locationFilter,
            string? jobFieldFilter, string? sort, int experienceFilter);
		Task<CustomResponse> GetPost(int postKey);
        Task<CustomResponse> AddPost(PostDto post);
        Task<CustomResponse> DeletePost(int postKey);
        Task<CustomResponse> UpdatePost(int postKey, PostDto post);
    }
}
