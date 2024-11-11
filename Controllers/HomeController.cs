using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbcontext _dbcontext;

        public HomeController(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.students.Add(student);
                _dbcontext.SaveChanges();
                TempData["success"] = "Student Registered successfully";
                return RedirectToAction("viewStudent", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ViewStudent()
        {
            var Student = _dbcontext.students.ToList();
            return View(Student);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var Student = _dbcontext.students.FirstOrDefault(x => x.Id == id);
            return View(Student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Student = _dbcontext.students.Find(id);
            return View(Student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.students.Update(student);
                _dbcontext.SaveChanges();
                TempData["update"] = "Student Update successfully";
                return RedirectToAction("viewStudent", "Home");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var Student = _dbcontext.students.Find(id);
            return View(Student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
         
                _dbcontext.students.Remove(student);
                _dbcontext.SaveChanges();
                TempData["delete"] = "Student delete successfully";
                return RedirectToAction("viewStudent", "Home");
           
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}