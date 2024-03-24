using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MainController : Controller
    {

         NoteManager noteManager = new NoteManager(new EfNoteDal());

      

        [HttpGet]
        public IActionResult Index()
        {
            
            var userId = HttpContext.Session.GetInt32("UserId"); // Kullanıcının oturum bilgisinden UserId'yi al
            var notes = noteManager.GetNotesByUserId(userId.Value);

            return View(notes);
        }

        
        public IActionResult DeleteNote(int id)
        {
            var values = noteManager.TGetByID(id);
            noteManager.TDelete(values);
            return RedirectToAction("Index","Main");
        }

        [HttpGet]
        public IActionResult UpdateNote(int id)
        {
         

            var values = noteManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateNote(Note note)
        {
            noteManager.TUpdate(note);
            return RedirectToAction("Index", "Main");
        }

        [HttpGet]
        public IActionResult AddNote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNote(Note note) 
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            note.UserId = userId.Value;

            noteManager.TInsert(note);
            return RedirectToAction("Index", "Main");
        }
    }
}
