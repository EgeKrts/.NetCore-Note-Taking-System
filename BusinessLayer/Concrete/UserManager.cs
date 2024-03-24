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
    public class UserManager : IUserService
    {
        private readonly IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return userDal.GetByUsernameAndPassword(username, password);
        }

        public void TDelete(User t)
        {
            userDal.Delete(t);
        }

        public User TGetByID(int id)
        {
           return userDal.GetById(id);
        }

        public List<User> TGetList()
        {
           return userDal.GetList();
        }

        public void TInsert(User t)
        {
           userDal.Insert(t);
        }

        public void TUpdate(User t)
        {
            userDal.Update(t);
        }
    }
}
