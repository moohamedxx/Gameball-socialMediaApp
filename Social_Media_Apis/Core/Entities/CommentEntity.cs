using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CommentEntity:BaseEntity
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? PictureUrl { get; set; }

        public PostEntity? Post { get; set; }
        public UserEntity? User { get; set; }

        
    }
}
