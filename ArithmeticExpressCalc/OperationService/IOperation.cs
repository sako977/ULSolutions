namespace OperationService
{
   /// <summary>
   /// Interface for the operators
   /// </summary>
   public interface  IOperation
   {
      /// <summary>
      /// PerformOperation- Perform calculation and returns the result.
      /// </summary>
      /// <param name="stringExpression"></param>
      /// <returns>double</returns>
      public double PerformOperation(string stringExpression);

      public double Divide(double first, double second);

      public double Multiply(double first, double second);
      
      public double Subtract(double first, double second);

      public double Add(double first, double second);

   }
}