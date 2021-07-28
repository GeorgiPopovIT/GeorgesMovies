using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static GeorgesMovies.Models.DataConstants;

namespace GeorgesMovies.Models.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }


        public ICollection<Comment> Comments { get; set; }
    }
}
