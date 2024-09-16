using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Apis.Dtos;
using Social_Media_Apis.Errors;

namespace Social_Media_Apis.Controllers
{
   
    public class UserController : ApiBaseController
    {
        private readonly IGenericRepository<UserEntity> userRepo;
        private readonly IMapper mapper;

        public UserController(IGenericRepository<UserEntity> userRepo , IMapper mapper)
        {
            this.userRepo = userRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var spec = new UserSpecification();
            var users= await userRepo.GetAllWithSpecAsync(spec);
            var mappedUser=mapper.Map<IEnumerable<UserEntity>,IEnumerable<UserDto>>(users);
            return Ok(mappedUser);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetUserById(int id)
        {
            var spec = new UserSpecification(id);
            var user=await userRepo.GetByIdWithSpecAsync(spec);
            if (user is null)
                return NotFound(new ApiErrorResponse(404,"User Not Found"));
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserEntity user)
        {
            await userRepo.CreateAsync(user);
            var res=userRepo.GetAllAsync();
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async  Task<ActionResult> EditUser(int id,UserEntity user)
        {
            if (id == user.Id)
            {
                await userRepo.UpdateAsync(id, user);
               var res=await  userRepo.GetByIdAsync(id);
                return Ok(res);
            }
            return BadRequest(new ApiErrorResponse(400,"id not equal user id"));
        }
        [HttpDelete("{id}")]
        public async Task< ActionResult> DeleteUser(int id)
        {
            var found=await GetUserById(id);
            if (found is null)
            {
                return NotFound(new ApiErrorResponse(404, "the user not found"));
            }
            await userRepo.DeleteAsync(id);
           
            return Ok("User Deleted Successfully");
        }
    }
}
