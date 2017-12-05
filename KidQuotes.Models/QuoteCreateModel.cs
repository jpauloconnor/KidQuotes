using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Models
{
    public class QuoteCreateModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(250)]
        public string Quote { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Description { get; set; }

        public override string ToString() => Quote;
    }
}
