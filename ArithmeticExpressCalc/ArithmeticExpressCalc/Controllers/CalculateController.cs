using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;

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

         // Check for non negative numbers
         if (stringExpression.StartsWith('-') 
            || stringExpression.Contains("+-")
            || stringExpression.Contains("--")
            || stringExpression.Contains("*-")
            || stringExpression.Contains("/-"))
         {
            return BadRequest("Only positive numbers allowed.");
         }

         // an input string of "4+5/2-1" should output 5.5

         // Used https://regex101.com/ to build the follong Regex patterns.
         Regex divideRegex = new Regex(@"\d+[\/]\d+");
         Regex multiplyRegex = new Regex(@"\d+[*]\d+");
         Regex addRegex = new Regex(@"\d+[+]\d+");
         Regex subtractRegex = new Regex(@"\d+[-]\d+");

         // Follow BODMAS rule: Support + - / * operators only.
         double divided = 0;
         double multiplied = 0;
         double added = 0;
         double subtracted = 0;

         DataTable dt = new DataTable();
         if (divideRegex.IsMatch(stringExpression))
         {
            foreach (string item in divideRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               divided = (double)dt.Compute(item, null);
            }
         }

         if (multiplyRegex.IsMatch(stringExpression))
         {
            foreach (string item in multiplyRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               multiplied = (double)dt.Compute(item, null);
            }
         }

         if (addRegex.IsMatch(stringExpression))
         {
            foreach (string item in addRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               added = (double)dt.Compute(item, null);
            }
         }

         if (subtractRegex.IsMatch(stringExpression))
         {
            foreach (string item in subtractRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               subtracted = (double)dt.Compute(item, null);
            }
         }

         double result = divided + multiplied + added + subtracted;
         return Ok(result);
      }
   }
}