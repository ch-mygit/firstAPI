using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Model
    {
        public class User
        {
            [Required]
            public int userId { get; set; }
            [Required]
            public string firstname { get; set; }
            [Required]
            public string lastname { get; set; }
            [Required]
            public string password { get; set; }
            [EmailAddress]
            public string email { get; set; }

        }
        public class LoginUser
        {
            [Required]
            public string password { get; set; }
            [EmailAddress]
            public string email { get; set; }
        }
    }
}
