using Microsoft.AspNetCore.Mvc;

namespace ArithmeticExpressCalc.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class CalculateController : ControllerBase
   {
      /// <summary>
      ///  Get - Get call to supply expression to perform calculation and return result.
      /// </summary>
      /// <param name="stringExpression"></param>
      /// <returns>IActionResult</returns>
      [HttpGet]
      public IActionResult Get(string stringExpression)
      {
         //GET api/ControllerName?stringExpression={value}


         return Ok();
      }
   }
}