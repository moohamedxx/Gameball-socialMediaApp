using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Apis.Errors;

namespace Social_Media_Apis.Controllers
{ 

    public class CommentController : ApiBaseController
    {
    private readonly IGenericRepository<CommentEntity> CommentRepo;

    public CommentController(IGenericRepository<CommentEntity> CommentRepo)
    {
        this.CommentRepo = CommentRepo;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentEntity>>> GetAllComments()
    {
        var Comments = await CommentRepo.GetAllAsync();
        return Ok(Comments);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentEntity>> GetCommentById(int id)
    {
        var user = await CommentRepo.GetByIdAsync(id);
            if(user is null)
            {
                return NotFound(new ApiErrorResponse(404, "Comments Not Found"));
            }
        return Ok(user);
    }

 

        [HttpPost]
    public async Task<ActionResult> AddComment(CommentEntity Comment)
    {
        await CommentRepo.CreateAsync(Comment);
         var res=   await CommentRepo.GetAllAsync();
        return Ok(res);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> EditComment(int id,CommentEntity Comment)
    {
            if (id == Comment.Id)
            {
                await CommentRepo.UpdateAsync(id,Comment);
                var res = await CommentRepo.GetByIdAsync(id);
                return Ok(res);
            }
            return BadRequest(new ApiErrorResponse(400,"the id not equal comment id"));
 
    }
    [HttpDelete("{id}")]
    public async Task <ActionResult> DeleteComment(int id)
    {
          var res= await CommentRepo.GetByIdAsync(id);
            if(res is null)
            {
                return NotFound(new ApiErrorResponse(404, "the comment not found"));
            }
            await CommentRepo.DeleteAsync(id);
            return Ok("the comment deleted successfully");
    }
}
}
