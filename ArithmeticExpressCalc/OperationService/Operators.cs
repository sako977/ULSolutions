using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationService
{
   internal class Operators : IOperators
   {
      /// <inheritdoc/>
      public int Add(params int[] numbers)
      {
         int result = 0;
         foreach (int i in numbers)
            result += i;

         return result;
      }

      /// <inheritdoc/>
      public int Divide(int num1,  int num2)
      {
         return num1 / num2;
      }

      /// <inheritdoc/>
      public int Multiply(params int[] numbers)
      {
         int result = 0;
         foreach (int i in numbers)
            result *= i;

         return result;
      }

      /// <inheritdoc/>
      public int Subtract(params int[] numbers)
      {
         int result = 0;
         foreach (int i in numbers)
            result -= i;

         return result;
      }
   }
}
