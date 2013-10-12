using System.Collections.Generic;
using Proto.Domain.QueryHandlers;
using Proto.Model.Entities;

namespace Proto.Domain.Queries.Tenants
{
    //public class GetTenantsQuery : IQuery<Tenant[]>, IQuery<IEnumerable<Tenant>>
    public class GetTenantsQuery : IQuery<IEnumerable<Tenant>>    
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
