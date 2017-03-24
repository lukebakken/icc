namespace Test
{
    using System.Collections.Generic;
    using System.Linq;
    using icclib;
    using Xunit;

    public class OperationRunnerTests
    {
        [Theory]
        [InlineData(1, "(((2 \u00d7 0) \u00d7 7) + 1)")]
        [InlineData(10, "((2 + 7) + (0 + 1))")]
        [InlineData(10, "((2 + 7) - (0 - 1))")]
        [InlineData(10, "((2 + 7) + (1 - 0))")]
        [InlineData(16, "((2 + 0) \u00d7 (1 + 7))")]
        [InlineData(16, "((2 - 0) \u00d7 (1 + 7))")]
        [InlineData(16, "((2 \u00d7 (1 + 7)) + 0)")]
        [InlineData(16, "((2 \u00d7 (1 + 7)) - 0)")]
        public void OutputsExpectedExpression(int value, string expr)
        {
            var ary = new int[] { 2, 0, 1, 7 };
            var runner = new OperationRunner(ary);
            IEnumerable<OpResult> rslt = runner.Run();
            Assert.Contains(expr, rslt.Select(r => r.ToString()));
        }
    }
}
