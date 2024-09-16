using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class PostEntity:BaseEntity
    {
        [Key]
       public int Id {  get; set; }
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public int UserId { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime DateOfCreation { get; set; }
        
        public UserEntity? User { get; set; }
        public ICollection<CommentEntity>? Comments { get; set; }
    }
}
