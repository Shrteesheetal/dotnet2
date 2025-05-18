using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace collegemanagementfirstproject.Controllers
{
    public class collegeDepartmentController : Controller
    {
        private readonly Icollegedepart _cdepartRepo;


        public collegeDepartmentController(Icollegedepart cdepart)
        {
            _cdepartRepo = cdepart;
        }
        public IActionResult Index()
        {
            IEnumerable<collegeDepartmentModel> cdepart = _cdepartRepo.GetAllcollegeDepartment();
            return View(cdepart);
        }

        [HttpGet]
        public IActionResult AddcollegeDepartment()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddcollegeDepartment(collegeDepartmentModel cd)
        {

            _cdepartRepo.InsertcollegeDepartment(cd);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult EditcollegeDepartment(int id)
        {
            var cdepart = _cdepartRepo.GetById(id);
            return View(cdepart);
        }
        [HttpPost]

        public ActionResult EditcollegeDepartment(collegeDepartmentModel cd)
        {
            _cdepartRepo.UpdatecollegeDepartment(cd);
            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public IActionResult DeletecollegeDepartment(int check)
        {
            var cdepart = _cdepartRepo.GetById(check);
            return View(cdepart);
        }
        [HttpPost]

        public ActionResult DeletecollegeDepartment(collegeDepartmentModel test)
        {
            _cdepartRepo.DeletecollegeDepartment(test);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult DetailcollegeDepartment(int fact)
        {
            var cdepart = _cdepartRepo.GetById(fact);
            return View(cdepart);
        }
    }
}
