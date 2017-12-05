using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Data
{
    public class QuoteEntity
    {
        [Key]
        public int QuoteId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Quote { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
