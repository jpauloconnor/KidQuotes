using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Models
{
    public class QuoteListModel
    {
        public int QuoteId { get; set; }

        public string Quote { get; set; }

        public string KidName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{QuoteId}] {Quote}";
    }
}
