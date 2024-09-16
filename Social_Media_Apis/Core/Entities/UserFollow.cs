using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserFollow:BaseEntity
    {
        
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public UserEntity Follower { get; set; }

        public int FollowedId { get; set; }
        public UserEntity Followed { get; set; }
    }
}
