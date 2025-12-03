using Microsoft.AspNetCore.Mvc;
using WebApi_Sravanthi.ServiceLayer;
using WebApi_Sravanthi.Services;

namespace WebApi_Sravanthi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DIController : Controller
    {
        private readonly TransientGuidService _transient1;
        
        private readonly ScopedGuidService _scoped1;
        
        private readonly SingletonGuidService _singleton1;
      

        public DIController(
            TransientGuidService transient1,
         
            ScopedGuidService scoped1,
       
            SingletonGuidService singleton1)
          
        {
            _transient1 = transient1;
        
            _scoped1 = scoped1;
        
            _singleton1 = singleton1;
            
        }

        [HttpGet("check-lifecycle")]
        public IActionResult GetGuids()
        {
            return Ok(new
            {
                Transient1 = _transient1.GetGuid(),
               
                Scoped1 = _scoped1.GetGuid(),
                
                Singleton1 = _singleton1.GetGuid(),
              
            });
        }
    }
}
