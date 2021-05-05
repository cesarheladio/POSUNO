using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSUNO.Api.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string Password { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
