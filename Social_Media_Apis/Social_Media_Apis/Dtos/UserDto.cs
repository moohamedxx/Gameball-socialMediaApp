using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Social_Media_Apis.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
   
        public string Email { get; set; }

        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<PostEntity> Posts { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
