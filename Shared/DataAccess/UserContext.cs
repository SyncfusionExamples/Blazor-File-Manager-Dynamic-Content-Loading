using Microsoft.EntityFrameworkCore;
using Demo.Data;

namespace Demo.Shared.DataAccess
{
    public class UserContext : DbContext
    {
        public virtual DbSet<UserDetails> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // The NORTHWND.MDF database is located in the Shared/App_Data folder of this repository.
                // The below connection string uses a path relative to the Demo.Shared project directory.
                var databasePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, @"..\..\..\..\Shared\App_Data\NORTHWND.MDF");
                optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='{System.IO.Path.GetFullPath(databasePath)}';Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
