namespace Test
{
    using icclib;
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
            int value = 20 / 17; // TODO FIXME not exact representation of value
            const string repr = "(20 \u00f7 17)";

            var op = new Division(a, b);
            Assert.Equal(value, op.Value);
            Assert.Equal(repr, op.ToString());
        }
    }
}
