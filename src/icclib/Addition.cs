namespace icclib
{
    public class Addition : BinaryOperation
    {
        public Addition(int a, int b)
            : base(a, b)
        {
        }

        public Addition(OpResult a, OpResult b)
            : base(a, b)
        {
        }

        protected override char Operator
        {
            get { return '+'; }
        }

        protected override int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}