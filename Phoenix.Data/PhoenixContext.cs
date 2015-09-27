namespace Phoenix.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Phoenix.Models;
    using System.Data.Entity;
    using Phoenix.Data.Migrations;

    public class PhoenixContext : IdentityDbContext<User>, IPhoenixContext
    {
        public PhoenixContext()
            : base("DefaultConnection")//, throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhoenixContext, Configuration>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static PhoenixContext Create()
        {
            return new PhoenixContext();
        }

        public IDbSet<UserLanguage> Languages { get; set; }

        public IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        public IDbSet<Interview> Interviews { get; set; }

        public IDbSet<Events> Events { get; set; }

        public IDbSet<NewsArticle> NewsArticles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //if we need on delete action
            //modelBuilder.Entity<Endorcement>().HasRequired(x => x.UserSkill).WithMany(x => x.Endorcements).WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
