using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrekkEnterpriseV4.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrekkEnterpriseV4.DAL
{
    public class EnterpriseContext : DbContext
    {
        public EnterpriseContext() : base("EnterpriseContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}