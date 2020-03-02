using SpaUserControl.Domain.Models;
using System.Data.Entity;
using SpaUserControl.Infraestructure.Data.Map;

namespace SpaUserControl.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base(@"Server=localhost;Database=spausercontrol;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
