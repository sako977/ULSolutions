namespace OperationService
{
   /// <summary>
   /// Interface for the operators
   /// </summary>
   interface  IOperators
   {
      /// <summary>
      /// Add() - Perform Addition
      /// </summary>
      /// <returns>int</returns>
      int Add(params int[] numbers);

      /// <summary>
      /// Add() - Perform Subtraction
      /// </summary>
      /// <returns>int</returns>
      int Subtract(params int[] numbers);

      /// <summary>
      /// Add() - Perform Multiplication
      /// </summary>
      /// <returns>int</returns>
      int Multiply(params int[] numbers);

      /// <summary>
      /// Add() - Perform Division
      /// </summary>
      /// <returns>int</returns>
      int Divide(params int[] numbers);
   }
}