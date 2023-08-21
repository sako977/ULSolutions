using System.Data;

namespace ArithmeticExpressCalcUnitTest
{
   public class UnitTest1
   {
      private readonly OperationService.IOperation operationService = new OperationService.Operation();

      [Fact]
      public void RunStringExpressionOperation()
      {
         DataTable dt = new DataTable();
         double result = operationService.PerformOperation("4+5*2");
         double correctAnswer = Convert.ToDouble(dt.Compute("4+5*2", null));
         Assert.True(result == correctAnswer, $"You answer {result}, and the correct answer is {correctAnswer}");
      }
   }
}