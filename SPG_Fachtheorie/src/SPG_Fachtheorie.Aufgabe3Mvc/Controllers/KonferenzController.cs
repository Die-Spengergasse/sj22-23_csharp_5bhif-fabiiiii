using AutoMapper.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe2;
using SPG_Fachtheorie.Aufgabe2.Model;
using System;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe3Mvc.Controllers
{
    [Route("[controller]/[action]")]

    public class KonferenzController : Controller
    {
        private readonly GradeContext _db;


        public KonferenzController(GradeContext db)
        {
            _db = db;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var classes = _db.Classes.ToList();
            return View(classes);
        }

        [HttpGet]
        public IActionResult Klasse(string klasse)
        {
            var students = _db.Students.Where(s => s.Class.Name==klasse)
                                        .Include(s => s.Grades)
                                        .ToList();

           
            var model = students.Select(s => new Student
            {
                Id = s.Id,
                Lastname = s.Lastname,
                Firstname = s.Firstname,
                Email = s.Email,
                Grades = s.Grades,
                ConferenceDecision = s.ConferenceDecision,

            }).ToList();

            

            return View(model);
        }



        [HttpGet]
        public IActionResult Beschluss(Guid id)
        {
            var model = _db.Students.Where(s => s.Id == id)
                .Include(s => s.Grades)
                .ThenInclude(s => s.Lesson)
                .First();

            return View(model);
        }

        public IActionResult BeschlussPost(Guid id, bool conferenceDecision)
        {
            var student = _db.Students
                .Include(s => s.Class)
                .First(s => s.Id == id);
           

            student.ConferenceDecision = conferenceDecision;
            _db.Update(student);
            _db.SaveChanges();


            return RedirectToAction("Klasse", new { klasse = student.Class.Name});

            
        }


        public IActionResult Anmeldung(Guid id)
        {
            var model = _db.Students.Where(s => s.Id == id)
                .Include(s => s.Grades)
                .ThenInclude(s => s.Lesson)
                .First();

            return View(model);
        }

        [HttpPost]
        public IActionResult AnmeldungPost(Guid id)
        {
            var student = _db.Students
                .Include(s => s.Grades)
                .Include(s => s.Class)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            if (student.Grades.Count(g => g.GradeValue == 5) == 0)
            {
                return RedirectToAction("Klasse", new { klasse = student.Class.Name });
            }

            return View(student);
        }
    }
}
