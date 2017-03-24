namespace icclib
{
    public class Multiplication : BinaryOperation
    {
        public Multiplication(int a, int b) : base(a, b) { }

        public Multiplication(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '\u00d7'; }
        }

        protected override int Calculate(int a, int b)
        {
            return a * b;
        }
    }
}