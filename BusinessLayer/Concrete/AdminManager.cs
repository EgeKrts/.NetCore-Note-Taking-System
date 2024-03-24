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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void TDelete(Admin t)
        {
            adminDal.Delete(t);
        }

        public Admin TGetByID(int id)
        {
          return adminDal.GetById(id);
        }

        public List<Admin> TGetList()
        {
            return adminDal.GetList();
        }

        public void TInsert(Admin t)
        {
           adminDal.Insert(t);
        }

        public void TUpdate(Admin t)
        {
            adminDal.Update(t);
        }
    }
}
