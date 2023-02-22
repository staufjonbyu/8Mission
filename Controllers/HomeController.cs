using _8Mission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _8Mission.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TaskContext _db;

        public HomeController(ILogger<HomeController> logger, TaskContext db)
        {
            _logger = logger;

            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quadrants()
        {

            ViewBag.Quadrant1 =  _db.tasks
                                    .Include(x => x.Category)
                                    .Where(x => x.Quadrant == 1)
                                    .OrderBy(x => x.Task_Name)
                                    .ToList();

            ViewBag.Quadrant2 = _db.tasks
                                    .Include(x => x.Category)
                                    .Where(x => x.Quadrant == 2)
                                    .OrderBy(x => x.Task_Name)
                                    .ToList();

            ViewBag.Quadrant3 = _db.tasks
                                    .Include(x => x.Category)
                                    .Where(x => x.Quadrant == 3)
                                    .OrderBy(x => x.Task_Name)
                                    .ToList();

            ViewBag.Quadrant4 = _db.tasks
                                    .Include(x => x.Category)
                                    .Where(x => x.Quadrant == 4)
                                    .OrderBy(x => x.Task_Name)
                                    .ToList();

            return View();
        }

        [HttpGet]
        public IActionResult TaskForm() //empty form
        {
            ViewBag.Category = _db.categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(Tasks task) //add new task
        {
            if (ModelState.IsValid) //checks for valid data
            {
                _db.Add(task);
                _db.SaveChanges();
                var data = _db.tasks
                    .Include(x => x.Category)
                    .OrderBy(x => x.Task_Name)
                    .ToList();
                return View("Quadrants");
            }

            else //if invalid, redirect to MovieForm Get Method
            {

                ViewBag.Category = _db.categories.ToList();

                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _db.tasks.FirstOrDefault(x => x.TaskID == id);

            ViewBag.Category = _db.categories.ToList();

            return View("TaskForm", task); //redircts to form view but gives it data to auto-fill
        }


        [HttpPost]
        public IActionResult Edit(Tasks t)
        {
            var task = _db.tasks.FirstOrDefault(x => x.TaskID == t.TaskID);
            if (task == null)
            {
                return NotFound();
            }

            task.Task_Name = t.Task_Name;
            task.Due_Date = t.Due_Date;
            task.Quadrant = t.Quadrant;
            task.Completed = t.Completed;
            task.CategoryID = t.CategoryID;
            

            _db.tasks.Update(task);
            _db.SaveChanges();

            return RedirectToAction("Quadrants");
        }


        public IActionResult Delete(int id)
        {
            var task = _db.tasks.FirstOrDefault(x => x.TaskID == id);

            _db.tasks.Remove(task);

            _db.SaveChanges();

            return RedirectToAction("Quadrants");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
