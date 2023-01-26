using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2;
using SPG_Fachtheorie.Aufgabe2.Model;
using System;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe3Mvc.Controllers
{

    [Route("[controller]/[action]")]
    public class PruefungController : Controller
    {
        private readonly GradeContext _db;


        public PruefungController(GradeContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Anmeldung(Guid id)
        {
            var model = _db.Exams
                .Include(s => s.Grade)
                .ThenInclude(s => s.Lesson)
                .Include(s => s.Grade)
                .ThenInclude(s => s.Student)  
               .Where(s => s.Grade.StudentId == id)
                .ToList();

            return View(model);
        }

       
    }
}
