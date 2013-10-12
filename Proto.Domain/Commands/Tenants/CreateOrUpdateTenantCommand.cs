
namespace Proto.Domain.Commands.Tenants
{
    public class CreateOrUpdateTenantCommand
    {
        public int TenantId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public System.Nullable<int> Active { get; set; }
        public string PrimaryContactFirstName { get; set; }
        public string PrimaryContactLastName { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public System.Guid RowGuid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ContactTypeId { get; set; }	

        //public Tenant Tenant { get; set; }

        //output property
        //public int TenantId { get; set; }
    }
}
