using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {

        UserManager userManager = new UserManager(new EfUserDal());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            userManager.TInsert(user);

            return RedirectToAction("Index");
        }
    }
}
