using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQuotes.Models
{
    public class QuoteEditModel
    {
        public int QuoteId { get; set; }
        public string Quote { get; set; }
        public string Description { get; set; }
        public string KidName { get; set; }

    }
}
