using System;
using System.Collections.Generic;
using System.Data.Entity;
using Appraisal.Core.Domain;
using Appraisal.Data.EFConfigurations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appraisal.Data
{
    public class EFDbContext : DbContext
    {
        public string ConnectionString { get; private set; }

        public EFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<EFDbContext>(null);
            ConnectionString = nameOrConnectionString;
        }

        public DbSet<Values> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ValuesConfiguration());
        }
    }
}
