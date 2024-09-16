using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public interface ISpecification<T> where T:BaseEntity
    {
        public Expression<Func<T,bool>> WhereEx { get; set; }
        public List<Expression<Func<T,object>>> IncludeEx { get; set; }
        public Expression<Func<T,object>> OrderByEx { get; set; }
        public Expression<Func<T,object>> OrderByDescendingEx { get; set; }
    }
}
