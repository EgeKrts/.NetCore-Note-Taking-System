using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());
        public IActionResult Index()
        {
            var values = userManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {    
            userManager.TInsert(user);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {


            var values = userManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            userManager.TUpdate(user);
            return RedirectToAction("Index", "Admin");
        }
    }
}
