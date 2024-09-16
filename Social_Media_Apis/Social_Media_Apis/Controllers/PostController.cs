using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Apis.Dtos;
using Social_Media_Apis.Errors;
using System.Reflection;

namespace Social_Media_Apis.Controllers
{

    public class PostController : ApiBaseController
    {
        private readonly IGenericRepository<PostEntity> PostRepo;
        private readonly IMapper mapper;

        public PostController(IGenericRepository<PostEntity> PostRepo, IMapper mapper)
        {
            this.PostRepo = PostRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPOSTS(string? sort)
        {
            var spec = new PostSpecification(sort);
            var Posts = await PostRepo.GetAllWithSpecAsync(spec);
            var mappedPost = mapper.Map<IEnumerable<PostEntity>, IEnumerable<PostDto>>(Posts);
            return Ok(mappedPost);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PostEntity), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 404)]
        public async Task<ActionResult<PostEntity>> GetPostById(int id)
        {

            var spec = new PostSpecification(id);
            var user = await PostRepo.GetByIdWithSpecAsync(spec);
            if (user is null)
                return NotFound(new ApiErrorResponse(404, "post not found"));
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> AddPost(PostEntity post)
        {
            await PostRepo.CreateAsync(post);
            var res = await GetAllPOSTS(null);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditPost(int id, PostEntity post)
        {
            if (id == post.Id)
            {
                await PostRepo.UpdateAsync(id, post);
                var res = await PostRepo.GetByIdAsync(id);
                return Ok(res);
            }
            else
            {
                return BadRequest(new ApiErrorResponse(400, "id not equal post id"));
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var found=await PostRepo.GetByIdAsync(id);
            if (found is null)
            {
                return NotFound(new ApiErrorResponse(404,"post not found here"));
            }
            await PostRepo.DeleteAsync(id);
           
            return Ok("Post Deleted Successfully");
        }
    }
}
