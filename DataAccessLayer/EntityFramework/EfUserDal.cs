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
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public User GetByUsernameAndPassword(string username, string password)
        {
            using var c = new Context();
            return c.Set<User>().FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
