using DataAccess.Interfaces;
using Entities.EntitiesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<CustomResponse> AddPost(PostDto post)
        {
            var result = await _postRepository.AddPost(post);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Post added successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Post not added.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> DeletePost(int postKey)
        {
            var result = await _postRepository.DeletePost(postKey);
            if (result > 0)
            {
                return new CustomResponse
                {
                    Data = null,
                    Message = "Post deleted successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Post not deleted.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }

        public async Task<CustomResponse> GetPost(int postKey)
        {
            var result = await _postRepository.GetPost(postKey);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Post found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Post not found.",
                StatusCode = (int)HttpStatusCode.NotFound,
                Success = false
            };
        }

        public async Task<CustomResponse> GetPosts(string? search, string? locationFilter,
            string? jobFieldFilter, string? sort, int experienceFilter)
		{
            var result = await _postRepository.GetPosts(search, locationFilter, jobFieldFilter, sort, experienceFilter);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Posts found.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Posts not found.",
                StatusCode = (int)HttpStatusCode.NotFound,
                Success = false
            };
        }

        public async Task<CustomResponse> UpdatePost(int postKey, PostDto post)
        {
            var result = await _postRepository.UpdatePost(postKey, post);
            if (result != null)
            {
                return new CustomResponse
                {
                    Data = result,
                    Message = "Post updated successfully.",
                    StatusCode = (int)HttpStatusCode.OK,
                    Success = true
                };
            }
            return new CustomResponse
            {
                Data = null,
                Message = "Post not updated.",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Success = false
            };
        }
    }
}
