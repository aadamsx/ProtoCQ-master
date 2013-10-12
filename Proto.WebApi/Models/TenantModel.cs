namespace Proto.WebApi.Models
{
    public class TenantModel
    {
        public TenantModel()
        {
            BillingAddress = new AddressModel();
        }
        public int TenantId { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        
        //public int? Type { get; set; }

        //public TenantType Type { get; set; }

        public int? Active { get; set; }

        public string PrimaryContactFirstName { get; set; }
        public string PrimaryContactLastName { get; set; }
        public string PrimaryContactPhone { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }


        public AddressModel BillingAddress { get; set; }

        //public Guid RowGuid { get; set; }
        //public DateTime ModifiedDate { get; set; }

        // ...

        // Relations and Navigation
        public int ContactTypeId { get; set; }
        public virtual ContactTypeMoel TypeMoel { get; set; }
    }
}