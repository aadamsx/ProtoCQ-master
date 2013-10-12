using System.Collections.Generic;
using System.Linq;
using Proto.Data.Query;
using Proto.Domain.Queries.Tenants;

namespace Proto.Domain.QueryHandlers
{
    public class TenantQueryHandlers :
        IQueryHandler<GetTenantByIdQuery, AllTenants>,
        //IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>>,
        IQueryHandler<GetCurrentTenantsQuery, IEnumerable<AllTenants>>
    {
        private ClientManagementContextEntities context;

        //public TenantQueryHandlers
        //    (ClientManagementContext context)
        //{
        //    this.context = context;
        //}

        public TenantQueryHandlers
            (ClientManagementContextEntities context)
        {
            this.context = context;
        }

        //public Tenant Handle(GetTenantByIdQuery query)
        //{
        //return context.Tenants.Find(query.TenatId);
        //}

        //public IEnumerable<Tenant> Handle(GetTenantsQuery query)
        //{
        //    return context.Tenants
        //        .Skip((query.PageIndex - 1) * query.PageSize)
        //        .Take(query.PageSize)
        //        .ToList(); 
        //}

        IEnumerable<AllTenants>
            IQueryHandler<GetCurrentTenantsQuery, IEnumerable<AllTenants>>
            .Handle(GetCurrentTenantsQuery query)
        {
            return context.AllTenants
                .AsNoTracking()
                //.OrderByDescending(t => t.Name)
                .OrderBy(t => t.Name)
                .Skip((query.PageIndex - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToList();
        }

        public AllTenants Handle(GetTenantByIdQuery query)
        {
            // If the return type was/is IQueryable<AllTenants>
            //return
            //    from tenant in context.AllTenants
            //    where tenant.TenantId == query.TenantId
            //    select tenant;

            return context.AllTenants
                .Find(query.TenantId);
        }
    }
}

