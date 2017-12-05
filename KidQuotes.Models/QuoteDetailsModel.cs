using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Models
{
    public class QuoteDetailsModel
    {
        public int QuoteId { get; set; }

        public string Quote { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString() => $"[{QuoteId}] {Quote}";
    }
}
