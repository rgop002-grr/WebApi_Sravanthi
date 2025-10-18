using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApi_Sravanthi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleBasedController : ControllerBase
    {
        // Endpoint only Admin can access
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-data")]
        public IActionResult GetAdminData()
        {
            return Ok("This data is accessible only by Admin!");
        }

        // Endpoint only User can access
        [Authorize(Roles = "User")]
        [HttpGet("user-data")]
        public IActionResult GetUserData()
        {
            return Ok("This data is accessible only by User!");
        }

        // Endpoint accessible by Admin or User
        [Authorize(Roles = "Admin,User")]
        [HttpGet("common-data")]
        public IActionResult GetCommonData()
        {
            return Ok("This data is accessible by Admin and User!");
        }

        // Endpoint accessible by any authenticated user
        [Authorize( Roles = "Manager")]
        [HttpGet("Manager-data")]
        public IActionResult Manager()
        {
            return Ok("This data is accessible by any authenticated user!");
        }

        [AllowAnonymous]
        [HttpGet("public-info")]
        public IActionResult GetPublicInfo()
        {
            return Ok("This endpoint is open to everyone — no token required!");
        }


    }
}