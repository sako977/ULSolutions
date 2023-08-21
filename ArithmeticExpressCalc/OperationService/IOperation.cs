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
   }
}