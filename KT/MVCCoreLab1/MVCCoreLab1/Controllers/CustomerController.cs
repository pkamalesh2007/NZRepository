using Microsoft.AspNetCore.Mvc;

namespace MVCCoreLab1.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Add()
        {
            return View("CustomerAdd");
        }

        public IActionResult Rec(string Value1)
        {
            return Content(Value1);
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
