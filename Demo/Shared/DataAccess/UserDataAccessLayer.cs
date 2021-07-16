using Microsoft.EntityFrameworkCore;
using Demo.Data;

namespace Demo.Shared.DataAccess
{
    public class UserDataAccessLayer
    {
        UserContext db = new UserContext();

        // returns the User data from the data base
        public DbSet<UserDetails> GetUser()
        {
            try
            {
                return db.User;
            }
            catch
            {
                throw;
            }
        }

        // Update the existing data in the data base
        public void UpdateUser(UserDetails name)
        {
            try
            {
                db.Entry(name).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
