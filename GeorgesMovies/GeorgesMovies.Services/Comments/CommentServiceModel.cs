using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeorgesMovies.Services.Comments
{
    public class CommentServiceModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }

        public int MovieId { get; set; }
        public IEnumerable<AllCommentsViewModel> Comments { get; set; }
    }
}
