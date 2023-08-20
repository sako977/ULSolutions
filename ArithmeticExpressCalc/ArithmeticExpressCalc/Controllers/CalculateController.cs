using Microsoft.AspNetCore.Mvc;

namespace ArithmeticExpressCalc.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class CalculateController : ControllerBase
   {
      public IActionResult Get()
      {
         return Ok();
      }
   }
}