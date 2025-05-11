using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Mvc;

namespace collegemanagementfirstproject.Controllers
{
    public class collegestudentController : Controller
    {
        private readonly Icollegestudent _cstudentRepo;

        public collegestudentController(Icollegestudent cstudent)
        {
            _cstudentRepo = cstudent;
        }
        public IActionResult Index()
        {
            IEnumerable<collegestudentModel> cstudent =_cstudentRepo.GetAllcollegestudent(); 
            return View(cstudent);
        }
   
        [HttpGet]
        public IActionResult Addcollegestudent()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Addcollegestudent(collegestudentModel  cs)
        {
            _cstudentRepo.Insertcollegestudent(cs);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Editcollegestudent( int id)
        {
            var cstudent =_cstudentRepo.GetById(id);
            return View(cstudent);
        }
        [HttpPost]

        public ActionResult Editcollegestudent(collegestudentModel cs)
        {
            _cstudentRepo.Updatecollegestudent(cs);
            return RedirectToAction(nameof(Index));
        }


       
       

        [HttpGet]
        public IActionResult Deletecollegestudent(int test)
        {
            var cstudent = _cstudentRepo.GetById(test);
            return View(cstudent);
        }
        [HttpPost]

        public ActionResult Deletecollegestudent(collegestudentModel cs)
        {
            _cstudentRepo.Deletecollegestudent(cs);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Detailcollegestudent(int id)
        {
            var cstudent = _cstudentRepo.GetById(id);
            return View(cstudent);
        }
    }
} 