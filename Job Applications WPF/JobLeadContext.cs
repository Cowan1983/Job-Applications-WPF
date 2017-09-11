using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Job_Applications_WPF
{
    class JobLeadContext : DbContext
    {

        public JobLeadContext() : base("name=JobLeadContext")
        {
            //Activate automatic database restructuring if the data model changes.
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<JobLeadContext, Job_Applications_WPF.Migrations.Configuration>("JobLeadContext"));
        }

        public DbSet<Broker> Brokers { get; set; }
        public DbSet<JobLead> JobLeads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Set up the n-n relationship between Employers and Agencies
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Broker>()
                .HasMany(p => p.Brokers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BrokerID");
                    m.MapRightKey("AssociatedBrokerID");
                    m.ToTable("BrokerAssociation");
                });

        }
         
    }
}
