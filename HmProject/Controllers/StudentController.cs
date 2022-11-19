using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HmProject.Models;
using HmProject.Models.Entities;

namespace HmProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var citiesList = _context.students.ToList();
            return View(citiesList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Students students)
        {

            _context.Add(students);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Update(int studentID)
        {
            var data = _context.students.Where(x => x.StudentID == studentID).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(int studentID, Students model)
        {
            var data = _context.students.FirstOrDefault(x => x.StudentID == studentID);
            try
            {

                data.StudentName = model.StudentName;
                data.Discription = model.Discription;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
  
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }


        }





        [HttpGet]
        public IActionResult Delete(int studentID)
        {
            var data = _context.students.Where(x => x.StudentID == studentID).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int cityId, Students model)
        {
            var data = _context.students.FirstOrDefault(x => x.StudentID == cityId);
            if (data != null)
            {
                data.StudentName = model.StudentName;

                _context.students.Remove(data);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }



    }

