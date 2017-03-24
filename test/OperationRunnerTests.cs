namespace Test
{
    using System.Collections.Generic;
    using icclib;
    using Xunit;

    public class OperationRunnerTests
    {
        [Theory]
        [InlineData("10 = ((2 + 7) + (0 + 1))")]
        [InlineData("10 = ((2 + 7) - (0 - 1))")]
        [InlineData("10 = ((2 + 7) + (1 - 0))")]
        public void OutputsExpectedExpression(string expr)
        {
            var ary = new int[] { 2, 0, 1, 7 };
            var r = new OperationRunner(ary);
            IEnumerable<string> exprs = r.Run();
            Assert.Contains(expr, exprs);
        }
    }
}
