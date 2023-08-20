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
      int Add();

      /// <summary>
      /// Add() - Perform Subtraction
      /// </summary>
      /// <returns>int</returns>
      int Subtract();

      /// <summary>
      /// Add() - Perform Multiplication
      /// </summary>
      /// <returns>int</returns>
      int Multiply();

      /// <summary>
      /// Add() - Perform Division
      /// </summary>
      /// <returns>int</returns>
      int Divide();
   }
}