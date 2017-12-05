using KidQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidQutoes.Contracts
{
    public interface IQuote
    {
        public bool CreateQuote(QuoteCreateModel model);
        public IEnumerable<NoteListItem> GetNotes();
        public NoteDetail GetNoteById(int noteId);
        public bool UpdateNote(NoteEdit model);
        public bool DeleteNote(int noteId);


    }
}
