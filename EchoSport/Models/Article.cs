using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EchoSport.Models
{
    public class Article
    {
        public int ID { get; set; }

        [StringLength(150, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Published on: ")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Sport { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
