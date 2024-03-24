using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNoteDal : GenericRepository<Note>, INoteDal
    {
      
       

        public List<Note> GetNotesByUserId(int userId)
        {
            using var c = new Context();
            return c.Set<Note>().Where(n => n.UserId == userId).ToList();
        }
    }
}
