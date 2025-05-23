using collegemanagementfirstproject.Interface;
using collegemanagementfirstproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace collegemanagementfirstproject.Controllers
{
    public class collegeFaculty : Controller
    {

        private readonly IcollegeFaculty _cfrepo;

        public collegeFaculty(IcollegeFaculty cfaculty)
        {
            _cfrepo = cfaculty;
        }
        public IActionResult Index()
        {
            IEnumerable<collegeFacultymodel> cfaculty = _cfrepo.GetAllcollegeFaculty();
            return View(cfaculty);
        }

        [HttpGet]
        public IActionResult AddcollegeFaculty()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddcollegeFaculty(collegeFacultymodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _cfrepo.InsertcollegeFaculty(model);
                    return Json(new { success = true, message = "Faculty added successfully!" });
                }

                return Json(new { success = false, message = "Invalid Faculty data." });
            }
            catch (Exception ex)//The method or operation is not implemented.'kin yasto vaneko hoo //data nai khali cha tei bhayera 
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }
        [HttpGet]
        public JsonResult AllcollegeFaculty()
        {
            
            var data = _cfrepo.GetAllcollegeFaculty();

            return Json(data);
        }

        [HttpPost]
        public JsonResult UpdatecollegeFaculty(collegeFacultymodel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _cfrepo.UpdatecollegeFaculty(model);
                    return Json(new { success = true, message = "Faculty Updated successfully!" });
                }

                return Json(new { success = false, message = "Invalid Courses data." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        //url: '/collegeFaculty/GetCollegeFacultyByID?FacultyID=' + id,
        public JsonResult GetCollegeFacultyByID(int FacultyID)
        {
            var cfaculty = _cfrepo.GetById(FacultyID);
            return Json(cfaculty);
        }
        [HttpGet]
        public IActionResult EditcollegeFaculty(int change)
        {
            var cfaculty = _cfrepo.GetById(change);
            return View(cfaculty);
        }
        [HttpPost]

        public ActionResult EditcollegeFaculty(collegeFacultymodel change)
        {
            _cfrepo.UpdatecollegeFaculty(change);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeletecollegeFaculty(int check)
        {
            var cfaculty = _cfrepo.GetById(check);
            return View(cfaculty);
        }
        [HttpPost]

        public ActionResult DeletecollegeFaculty(collegeFacultymodel check)
        {
            _cfrepo.DeletecollegeFaculty(check);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult DetailcollegeFaculty(int Detail)
        {
            var cfaculty = _cfrepo.GetById(Detail);
            return View(cfaculty);
        }
        [HttpGet]
        public IActionResult IndexforJs()
        {
            return View();
        }

    }
}
