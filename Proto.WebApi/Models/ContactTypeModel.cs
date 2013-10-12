using System.Collections.Generic;
using Proto.Model.Entities;

namespace Proto.WebApi.Models
{
    public class ContactTypeMoel
    {
        // Primary key
        public int ContactTypeId { get; set; }

        // Property
        public string Name { get; set; }

        // Entity mapping
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
