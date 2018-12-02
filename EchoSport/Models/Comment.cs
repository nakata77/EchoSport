using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoSport.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required] public int ArticleId { get; set; }

        [Required] public string User { get; set; }

        [Display(Name = "Published on: ")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [StringLength(50, MinimumLength = 10)]
        [Required]
        public string Text { get; set; }
        
    }
}
