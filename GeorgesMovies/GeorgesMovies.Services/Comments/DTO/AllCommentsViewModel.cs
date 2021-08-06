using System;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Services.Comments.DTO
{
    public class AllCommentsViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }

        [Required]
        [MinLength(5,ErrorMessage = "Minimum {1} characters")]
        public string Message { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
