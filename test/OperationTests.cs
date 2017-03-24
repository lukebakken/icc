namespace Test
{
    using icclib;
    using Microsoft.SolverFoundation.Common;
    using Xunit;

    public class OperationTests
    {
        [Fact]
        public void Addition()
        {
            int a = 20;
            int b = 17;
            int value = 20 + 17;
            const string repr = "(20 + 17)";

            var op = new Addition(a, b);
            Assert.Equal(value, op.Value);
            Assert.Equal(repr, op.ToString());
        }

        [Fact]
        public void Subtraction()
        {
            int a = 20;
            int b = 17;
            int value = 20 - 17;
            const string repr = "(20 - 17)";

            var op = new Subtraction(a, b);
            Assert.Equal(value, op.Value);
            Assert.Equal(repr, op.ToString());
        }

        [Fact]
        public void Multiplication()
        {
            int a = 20;
            int b = 17;
            int value = 20 * 17;
            const string repr = "(20 \u00d7 17)";

            var op = new Multiplication(a, b);
            Assert.Equal(value, op.Value);
            Assert.Equal(repr, op.ToString());
        }

        [Fact]
        public void Division()
        {
            int a = 20;
            int b = 17;
            Rational value = Rational.Get(20, 17);
            const string repr = "(20 \u00f7 17)";

            var op = new Division(a, b);
            Assert.Equal(value, op.Value);
            Assert.Equal(repr, op.ToString());
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        [InlineData(7, 5040)]
        [InlineData(8, 40320)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        [InlineData(11, 39916800)]
        [InlineData(12, 479001600)]
        [InlineData(13, 6227020800)]
        [InlineData(14, 87178291200)]
        [InlineData(15, 1307674368000)]
        [InlineData(16, 20922789888000)]
        [InlineData(17, 355687428096000)]
        [InlineData(18, 6402373705728000)]
        [InlineData(19, 121645100408832000)]
        [InlineData(20, 2432902008176640000)]
        public void Factorial(int n, long fact)
        {
            long calcd = IterFactorial(n);
            var op = new Factorial(n);
            Assert.Equal(fact, op.Value);
            Assert.Equal(calcd, op.Value);
        }

        private static long IterFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            long result = 1;
            for (long i = 2; i <= n; i++)
            {
                result = result * i;
            }

            return result;
        }
    }
}