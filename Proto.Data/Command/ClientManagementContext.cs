﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Proto.Data.Configuration;
using Proto.Model.Entities;

namespace Proto.Data.Command
{
    public class ClientManagementContext 
        : DbContext, IClientManagementContext
    {
//        static ClientManagementContext()
//        {
//#if DEBUG
//            Database.SetInitializer<ClientManagementContext>
//                (new DropCreateIfChangeInitializer());
//#else
//            Database.SetInitializer<ClientManagementContext> 
//                (new CreateInitializer ());
//#endif
//        }
        public ClientManagementContext()
            : base("Name=ClientManagementContext")
        {
            //Configuration.LazyLoadingEnabled = true;

        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // Added these options, might remove them after load testing ...
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add any configuration or mapping stuff here
            modelBuilder.Configurations.Add(new TenantConfig());
            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new ContactTypeConfig());
        }

    }
}
