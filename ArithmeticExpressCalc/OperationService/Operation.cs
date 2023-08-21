using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OperationService
{
   public class Operation : IOperation
   {
      /// <inheritdoc/>
      public double PerformOperation(string stringExpression)
      {
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
               divided += Convert.ToDouble(dt.Compute(item, null));
               stringExpression = stringExpression.Replace(item, string.Empty);
               FrequentSymbolSanityCheck(ref stringExpression);
            }
         }

         if (multiplyRegex.IsMatch(stringExpression))
         {
            foreach (string item in multiplyRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               multiplied += Convert.ToDouble(dt.Compute(item, null));
               stringExpression = stringExpression.Replace(item, string.Empty);
               FrequentSymbolSanityCheck(ref stringExpression);
            }
         }

         if (addRegex.IsMatch(stringExpression))
         {
            foreach (string item in addRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               added += Convert.ToDouble(dt.Compute(item, null));
               stringExpression = stringExpression.Replace(item, string.Empty);
               FrequentSymbolSanityCheck(ref stringExpression);
            }
         }

         if (subtractRegex.IsMatch(stringExpression))
         {
            foreach (string item in subtractRegex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               subtracted += Convert.ToDouble(dt.Compute(item, null));
               stringExpression = stringExpression.Replace(item, string.Empty);
               FrequentSymbolSanityCheck(ref stringExpression);
            }
         }

         FrequentSymbolSanityCheck(ref stringExpression);

         double result = 0;
         if (!string.IsNullOrWhiteSpace(stringExpression))
            result = Convert.ToDouble(stringExpression);

           result =  result + divided + multiplied + added + subtracted;
         return result;
      }

      private void FrequentSymbolSanityCheck(ref string strExpression)
      {
         if (strExpression.Contains("+-"))
            strExpression = strExpression.Replace("+-", "-");

         if (strExpression.Contains("-+"))
            strExpression = strExpression.Replace("-+", "-");

         if (strExpression.Contains('/'))
            strExpression = strExpression.Replace("/", string.Empty);

         if (strExpression.Contains('*'))
            strExpression = strExpression.Replace("*", string.Empty);

         if (strExpression.Contains('+'))
            strExpression = strExpression.Replace("+", string.Empty);

         if (strExpression.Contains('-'))
            strExpression = strExpression.Replace("-", string.Empty);
      }
   }
}
