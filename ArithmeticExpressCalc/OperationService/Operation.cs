using System.Data;
using System.Text.RegularExpressions;

namespace OperationService
{
   public class Operation : IOperation
   {
      /// <inheritdoc/>
      public double PerformOperation(string stringExpression)
      {
         // Nonnegative integers and the + - / * operators only as stated on the question.

         // Used https://regex101.com/ to build the follong Regex patterns.

         List<Regex> regexes = new List<Regex>()
         { 
            // Follow BODMAS rule here.
            new Regex(@"\d+[\/]\d+"), // Divison
            new Regex(@"\d+[*]\d+"),  // Multiplication
            new Regex(@"\d+[+]\d+"),  // Addition
            new Regex(@"\d+[-]\d+")   // Subtraction
         };

         double result = 0;
         foreach (Regex regex in regexes)
            result += ArithmeticCalc(ref stringExpression, regex);

         if (!string.IsNullOrWhiteSpace(stringExpression)) // Remove trailing symbols before adding.
            result += Convert.ToDouble(stringExpression.Remove(stringExpression.Length - 1));

         return result;
      }

      public double Divide(double first, double second)
      {
         return first / second;
      }

      public double Multiply(double first, double second)
      {
         return first * second;
      }

      public double Subtract(double first, double second)
      {
         return first - second;
      }

      public double Add(double first, double second)
      {
         return first + second;
      }

      private double ArithmeticCalc(ref string stringExpression, Regex regex)
      {
         // Follow BODMAS rule: Support + - / * operators only.

         double finalValue = 0;
         if (regex.IsMatch(stringExpression))
         {
            foreach (string item in regex.Matches(stringExpression).Select(m => m.Groups[0].Value).ToArray())
            {
               if (item.Contains("/"))
               {
                  string[] splitted = item.Split('/');
                  finalValue += Divide(Convert.ToDouble(splitted[0]), Convert.ToDouble(splitted[1]));
               }
               else if (item.Contains("*"))
               {
                  string[] splitted = item.Split('*');
                  finalValue += Multiply(Convert.ToDouble(splitted[0]), Convert.ToDouble(splitted[1]));
               }
               else if (item.Contains("+"))
               {
                  string[] splitted = item.Split('+');
                  finalValue += Add(Convert.ToDouble(splitted[0]), Convert.ToDouble(splitted[1]));
               }
               else if (item.Contains("-"))
               {
                  string[] splitted = item.Split('-');
                  finalValue += Subtract(Convert.ToDouble(splitted[0]), Convert.ToDouble(splitted[1]));
               }

               stringExpression = stringExpression.Replace(item, string.Empty);
               FrequentSymbolsSanityChecks(ref stringExpression);
            }
         }

         return finalValue;
      }

      private void FrequentSymbolsSanityChecks(ref string strExpression)
      {
         if (strExpression.Contains("+-"))
         {
            strExpression = strExpression.Replace("+-", "-");
         }
         else if (strExpression.Contains("-+"))
         {
            strExpression = strExpression.Replace("-+", "-");
         }
         else if (strExpression.Contains("++"))
         {
            strExpression = strExpression.Replace("++", "+");
         }
         else if (strExpression.Contains("--"))
         {
            strExpression = strExpression.Replace("--", "+");
         }
      }
   }
}
