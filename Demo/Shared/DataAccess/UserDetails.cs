using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    public class UserDetails
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }

    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
