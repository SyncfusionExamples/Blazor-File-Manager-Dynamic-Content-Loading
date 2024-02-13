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
                // To make the sample runnable, replace your local file path for the MDF file here 
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\GitHub\SyncfusionExamples\FileManager\dynamic-content-loading\file\Blazor-File-Manager-Dynamic-Content-Loading\Demo\Shared\App_Data\NORTHWND.MDF';Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
