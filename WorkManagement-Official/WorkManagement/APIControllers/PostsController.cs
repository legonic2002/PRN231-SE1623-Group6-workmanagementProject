using DataAccess;
using DataAccess.Interfaces;
using Entities.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WorkManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<CustomResponse> GetPosts(string? search, string? locationFilter,
			string? jobFieldFilter, string? sort, int experienceFilter = 0)
		{
           return await _postService.GetPosts(search, locationFilter, jobFieldFilter, sort, experienceFilter);
		}

        [HttpGet("{postKey}")]
        public async Task<CustomResponse> GetPost(int postKey)
        {
            return await _postService.GetPost(postKey);
        }

        [HttpPut("{postKey}")]
        public async Task<CustomResponse> PutPost(int postKey, PostDto post)
        {
            return await _postService.UpdatePost(postKey, post);
        }

        [HttpPost]
        public async Task<CustomResponse> PostPost(PostDto post)
        {
            return await _postService.AddPost(post);
        }

        [HttpDelete("{postKey}")]
        public async Task<CustomResponse> DeletePost(int postKey)
        {
            return await _postService.DeletePost(postKey);
        }
    }
}
