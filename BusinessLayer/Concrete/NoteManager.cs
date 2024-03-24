using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal noteDal;

        public NoteManager(INoteDal noteDal)
        {
            this.noteDal = noteDal;
        }

        public List<Note> GetNotesByUserId(int userId)
        {
           return noteDal.GetNotesByUserId(userId);
        }

        public void TDelete(Note t)
        {
           noteDal.Delete(t);
        }

        public Note TGetByID(int id)
        {
            return noteDal.GetById(id);
        }

        public List<Note> TGetList()
        {
           return noteDal.GetList();
        }

        public void TInsert(Note t)
        {
           noteDal.Insert(t);
        }

        public void TUpdate(Note t)
        {
            noteDal.Update(t);
        }
    }
}
