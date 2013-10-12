﻿using System.Collections.Generic;
﻿using Proto.Data.Query;
﻿using Proto.Domain.QueryHandlers;

namespace Proto.Domain.Queries.Tenants
{
    public class GetCurrentTenantsQuery : IQuery<IEnumerable<AllTenants>>    
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

