using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class UserSpecification:Specification<UserEntity>
    {
        public UserSpecification()
        {
            this.IncludeEx.Add(p=>p.Posts);
           
            
        }
        public UserSpecification(int id):base(p=>p.Id==id)
        {
            this.IncludeEx.Add(p=>p.Posts);
           
        }
    }
}
