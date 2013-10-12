using System.ComponentModel.DataAnnotations;
using Proto.Data.Query;
﻿using Proto.Domain.QueryHandlers;

namespace Proto.Domain.Queries.Tenants
{
    public class GetTenantByIdQuery : IQuery<AllTenants>
    {
        public int TenantId { get; set; }
    }
}



