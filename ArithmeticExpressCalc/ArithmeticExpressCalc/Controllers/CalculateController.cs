using Microsoft.AspNetCore.Mvc;

namespace ArithmeticExpressCalc.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class CalculateController : ControllerBase
   {
      private readonly OperationService.IOperation operationService = new OperationService.Operation();

      /// <summary>
      ///  Get - Get call to supply expression to perform calculation and return result.
      /// </summary>
      /// <param name="stringExpression"></param>
      /// <returns>IActionResult</returns>
      [HttpGet]
      public IActionResult Get(string stringExpression)
      {
         //GET api/ControllerName?stringExpression={value}

         // Check for non negative numbers
         if (stringExpression.StartsWith('-') 
            || stringExpression.Contains("+-")
            || stringExpression.Contains("--")
            || stringExpression.Contains("*-")
            || stringExpression.Contains("/-"))
         {
            return BadRequest("Only positive numbers allowed.");
         }

         var result = operationService.PerformOperation(stringExpression);
         return Ok(result);
      }
   }
}