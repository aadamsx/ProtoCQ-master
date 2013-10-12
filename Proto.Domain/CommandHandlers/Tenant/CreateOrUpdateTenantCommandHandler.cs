using System;
using System.Data.Entity;
using Proto.Data.Command;
using Proto.Domain.Commands.Tenants;
using Proto.Model.Entities;

namespace Proto.Domain.CommandHandlers.Tenant
{
    public class CreateOrUpdateTenantCommandHandler : ICommandHandler<CreateOrUpdateTenantCommand>
    {
        private ClientManagementContext db;
        public CreateOrUpdateTenantCommandHandler(ClientManagementContext context)
        {
            db = context;
        }

        void ICommandHandler<CreateOrUpdateTenantCommand>.Handle(CreateOrUpdateTenantCommand command)
        {
            var tenant = new Model.Entities.Tenant
            {
                TenantId = command.TenantId,
                Name = command.Name,
                //public int? Type { get; set; }
                //public TenantType Type { get; set; }
                Active = command.Active,
                PrimaryContactFirstName = command.PrimaryContactFirstName,
                PrimaryContactLastName = command.PrimaryContactLastName,
                PrimaryContactPhone = command.PrimaryContactPhone,
                Description = command.Description,
                Email = command.Email,
                OfficePhone = command.OfficePhone,
                BillingAddress = new Address
                {
                    City = command.City, 
                    State = command.State, 
                    Street = command.Street, 
                    Zip = command.Zip
                },
                //RowGuid
                // this should be updated in the database, not here
                ModifiedDate = DateTime.Now,
                // Relations and Navigation
                // Note: this should be a drop down
                ContactTypeId = command.ContactTypeId
                //ContactType Type { get; set; }
            };

            // A) Optimistic.

            // Cheap writes:
            // you can make these kinds of don't-care writes cheaper by using a different Context variation
            // just disabling some extra calls EF makes on your behalf that you're ignoring the results of anyway
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;
            
            // unsure whether an object has been added or modified
            // You need to take these actions on all of the objects being added/modified, 
            // so if this object is complex and has other objects that need to be updated 
            // in the DB via FK relationships, you need to set their EntityState as well.
            //db.Entry(tenant).State = tenant.TenantId == 0
            //    ? EntityState.Added
            //    : EntityState.Modified;

            if (tenant.TenantId == 0)
            {
                // should allow the database to create this
                tenant.RowGuid = Guid.NewGuid();
                // also need the account number to be generated

                db.Entry(tenant).State = EntityState.Added;
            }
            else
            {
                db.Entry(tenant).State = EntityState.Modified;
            }

            db.SaveChanges();



            // B) Pessimistic. You can actually query the DB to verify the data 
            // hasn't changed/been added since you last picked it up, 
            // then update it if it's safe.

            // var existing = db.Customers.Find(customer.Id);
            // Some logic here to decide whether updating is a good idea, like
            // verifying selected values haven't changed, then

            // db.Entry(existing).CurrentValues.SetValues(customer);

            // Set output properties
            command.TenantId = tenant.TenantId;
            command.RowGuid = tenant.RowGuid;
            command.ModifiedDate = tenant.ModifiedDate;
            command.AccountNumber = tenant.AccountNumber;
        }
    }
}
