using System.Data;

namespace ArithmeticExpressCalcUnitTest
{
   public class UnitTest1
   {
      private readonly OperationService.IOperation operationService = new OperationService.Operation();

      [Theory]
      [InlineData("4+5*2")]
      [InlineData("4+5/2")]
      [InlineData("4+5/2-1")]
      [InlineData("453+34*9")]
      [InlineData("136+89*77")]
      [InlineData("1+758*2")]
      [InlineData("43+506*85")]
      public void Run_String_Expression_Operations(string mathExpression)
      {
         DataTable dt = new DataTable();
         double result = operationService.PerformOperation(mathExpression);
         double correctAnswer = Convert.ToDouble(dt.Compute(mathExpression, null));
         Assert.True(result == correctAnswer, $"You answer {result}, and the correct answer is {correctAnswer}");
      }
   }
}