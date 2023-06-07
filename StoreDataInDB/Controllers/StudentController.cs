using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreDataInDB.Models;
using StoreDataInDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StoreDataInDB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly StudentRepository _studentRepository = null;
       
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;         
        }

        public ViewResult AddNewStudent()
        {
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(StudentModel studentModel)
        {         
        
                int id = await _studentRepository.AddNewStudent(studentModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewStudent));
                }
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");

            return View();
        }

        public async Task<ViewResult> GetAllStudent()
        {
            var data = await _studentRepository.GetAllStudent();
            return View(data);
        }

        [Route("studentdetail/{id}")]
        public async Task<ViewResult> GetStudentbyId(int id)
        {
            var data = await _studentRepository.GetStudentById(id);
            return View(data);
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id=1, Text="Hindi"},
                new LanguageModel(){ Id=2, Text="English"},
                new LanguageModel(){ Id=3, Text="french"}
            };
        }
    }
}
