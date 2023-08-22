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

      /// <summary>
      /// Division
      /// </summary>
      /// <param name="first"></param>
      /// <param name="second"></param>
      /// <returns></returns>
      public double Divide(double first, double second);

      /// <summary>
      /// Multiplication
      /// </summary>
      /// <param name="first"></param>
      /// <param name="second"></param>
      /// <returns></returns>
      public double Multiply(double first, double second);
      
      /// <summary>
      /// Subtraction
      /// </summary>
      /// <param name="first"></param>
      /// <param name="second"></param>
      /// <returns></returns>
      public double Subtract(double first, double second);

      /// <summary>
      /// Addition
      /// </summary>
      /// <param name="first"></param>
      /// <param name="second"></param>
      /// <returns></returns>
      public double Add(double first, double second);

   }
}