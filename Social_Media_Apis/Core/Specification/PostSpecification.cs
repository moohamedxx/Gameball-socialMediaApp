using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class PostSpecification:Specification<PostEntity>
    {
        public PostSpecification(string?sort)
        {
            this.IncludeEx.Add(p=>p.User);
            this.IncludeEx.Add(p=>p.Comments);
            if(!string.IsNullOrEmpty(sort))
            {
                this.OrderByEx=p=>p.Title;
            }
        }
        public PostSpecification(int id):base(p=>p.Id==id)
        {
            this.IncludeEx.Add(p => p.User);
            this.IncludeEx.Add(p => p.Comments);
            
        }
    }
}
