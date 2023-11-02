using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPostRepository
    {
        Task<IList<PostDto>?> GetPosts(string? search, string? locationFilter,
            string? jobFieldFilter, string? sort, int experienceFilter);

		Task<PostDto?> GetPost(int postKey);
        Task<PostDto?> AddPost(PostDto post);
        Task<PostDto?> UpdatePost(int postKey, PostDto post);
        Task<int> DeletePost(int postKey);
    }
}
