using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class UserEntity:BaseEntity
    {
        [Key]
       public  int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(100),EmailAddress]
        public string Email { get; set; }
        [Required,MaxLength(100),PasswordPropertyText]
        public string Password { get; set; }
        public string? ProfilePicture { get; set; }
        public ICollection<PostEntity>? Posts { get; set; }
        public ICollection<CommentEntity>? Comments { get; set; }
        public ICollection<UserFollow>? Followers { get; set; } = new List<UserFollow>();
        public ICollection<UserFollow>? Following { get; set; } = new List<UserFollow>();





    }
}
