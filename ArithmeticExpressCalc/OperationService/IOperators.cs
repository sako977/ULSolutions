namespace OperationService
{
   interface  IOperators
   {
      Task<int> Add();
      Task<int> Subtract();
      Task<int> Multiply();
      Task<int> Divide();
   }
}