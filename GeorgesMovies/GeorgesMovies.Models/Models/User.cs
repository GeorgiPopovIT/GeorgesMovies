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
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
