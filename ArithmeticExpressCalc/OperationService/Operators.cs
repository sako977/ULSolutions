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
      public int Add()
      {
         int test = (1 + 1);
         return test;
      }

      /// <inheritdoc/>
      public int Divide()
      {
         throw new NotImplementedException();
      }

      /// <inheritdoc/>
      public int Multiply()
      {
         throw new NotImplementedException();
      }

      /// <inheritdoc/>
      public int Subtract()
      {
         throw new NotImplementedException();
      }
   }
}
