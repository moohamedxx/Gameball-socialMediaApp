using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class SpecificationEval<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> DbContext , ISpecification<T> spec)
        {

            var query = DbContext;
            if(spec.WhereEx is not null)
            {
                query=query.Where(spec.WhereEx);
            }
            if(spec.OrderByEx is not null)
                query=query.OrderBy(spec.OrderByEx);
            query=spec.IncludeEx.Aggregate(query,(Accu,Current)=>Accu.Include(Current));
            return query;
        }
    }
}
