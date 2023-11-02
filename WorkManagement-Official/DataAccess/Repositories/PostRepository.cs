using AutoMapper;
using DataAccess.Entities;
using DataAccess.Helpers;
using DataAccess.Interfaces;
using Entities.EntitiesDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public class PostRepository : IPostRepository
	{
		private readonly WorkManagementStableContext _context;
		private readonly IMapper _mapper;

		public PostRepository(WorkManagementStableContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<PostDto?> AddPost(PostDto post)
		{
			try
			{
				var postAdded = _mapper.Map<Post>(post);
				await _context.Posts.AddAsync(postAdded);
				if (await _context.SaveChangesAsync() > 0)
				{
					return _mapper.Map<PostDto>(postAdded);
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public async Task<int> DeletePost(int postKey)
		{
			try
			{
				var post = await _context.Posts.FindAsync(postKey);
				if (post != null)
				{
					_context.Posts.Remove(post);
				}
				return await _context.SaveChangesAsync();
			}
			catch
			{
				return -1;
			}
		}

		public async Task<PostDto?> GetPost(int postKey)
		{
			try
			{
				var post = await _context.Posts.FindAsync(postKey);
				if (post != null)
				{
					return _mapper.Map<PostDto>(post);
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public async Task<IList<PostDto>?> GetPosts(string? search, string? locationFilter,
            string? jobFieldFilter, string? sort, int experienceFilter)
		{
			try
			{
				var posts = _context.Posts.Include(x => x.CompanyKeyNavigation).AsQueryable();

				var result_raw = await posts
					.Where(p => (string.IsNullOrEmpty(search) || p.Title.ToLower().Contains(search.ToLower()))
						&& (string.IsNullOrEmpty(locationFilter) || p.CompanyKeyNavigation.Location.Equals(locationFilter))
						&& (string.IsNullOrEmpty(jobFieldFilter) || p.JobField.Equals(jobFieldFilter))
						&& (experienceFilter == 0 || p.Experience == experienceFilter)
					).ToListAsync();
				if (!string.IsNullOrEmpty(sort))
				{
					if(sort.Equals("title", StringComparison.OrdinalIgnoreCase))
					{
                        result_raw.OrderBy(p => p.Title);
					}else if (sort.Equals("salary", StringComparison.OrdinalIgnoreCase))
					{
                        result_raw.OrderBy(p => p.Salary);
					}
				}
				var result = result_raw.Select(post => _mapper.Map<PostDto>(post)).ToList();
				foreach (var post in result)
				{
                    post.CompanyDto = _mapper.Map<CompanyDto>(await _context.Companies.FirstOrDefaultAsync(c => c.CompanyKey == post.CompanyKey));
                }
				return result.ToList();
			}
			catch
			{
				return null;
			}
		}

		public async Task<PostDto?> UpdatePost(int postKey, PostDto post)
		{
			try
			{
				var oldPost = await _context.Companies.FindAsync(postKey);
				if (oldPost != null)
				{
					var postUpdated = _mapper.Map<Post>(post);
					foreach (var property in postUpdated.GetType().GetProperties())
					{
						if (property.GetValue(postUpdated) == null || property.GetValue(postUpdated)!.ToString()!.Trim().Equals(""))
						{
							property.SetValue(postUpdated, property.GetValue(oldPost));
						}
					}
					_context.Entry(oldPost).CurrentValues.SetValues(post);
					if (_context.Entry(oldPost).State == EntityState.Unchanged)
					{
						return post;
					}
					if (await _context.SaveChangesAsync() > 0)
					{
						return post;
					}
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
	}
}
