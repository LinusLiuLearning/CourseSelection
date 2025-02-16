using Microsoft.AspNetCore.Mvc;

namespace CourseSelection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseSelectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
