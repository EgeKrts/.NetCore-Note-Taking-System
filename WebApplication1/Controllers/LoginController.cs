using Microsoft.AspNetCore.Mvc;

using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework; 

public class LoginController : Controller
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
        // Kullanıcıyı doğrulama işlemi
        var result = userManager.GetByUsernameAndPassword(user.UserName, user.Password);

        if (result != null)
        {
            // Giriş başarılı ise kullanıcı kimliğini oturum değişkenine atayalım
            HttpContext.Session.SetInt32("UserId", result.UserId);

            // Ana sayfaya yönlendir
            return RedirectToAction("Index", "Main");
        }
        else
        {
            // Giriş başarısız ise hata mesajı göster ve giriş sayfasını tekrar göster
            ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            return View();
        }
    }
}