using Microsoft.AspNetCore.Mvc;

namespace WebApi_Sravanthi.Controllers
{
    public class ConventionalController : Controller

    {
        public IActionResult Index()
        {
            return Ok("This is Home/Index from Conventional Routing");
        }

        public IActionResult About()
        {
            return Ok("This is Home/About using Conventional Routing");
        }

        public IActionResult Details(int id)
        {
            return Ok($"Conventional Routing Example: Employee ID = {id}");
        }
    }
}

//namespace WebApi_Sravanthi.Controllers
//{
//    public class ConventionalRouteController : ControllerBase
//    {
//        [HttpGet("index")]
//        public IActionResult Index()
//        {
//            return Ok("This is Home/Index from API Routing");
//        }

//        [HttpGet("about")]
//        public IActionResult About()
//        {
//            return Ok("This is Home/About using API Routing");
//        }

//        [HttpGet("details/{id}")]
//        public IActionResult Details(int id)
//        {
//            return Ok($"API Routing Example: Employee ID = {id}");
//        }
//    }
//}

