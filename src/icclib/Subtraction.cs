namespace icclib
{
    public class Subtraction : BinaryOperation
    {
        public Subtraction(int a, int b) : base(a, b) { }

        public Subtraction(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '-'; }
        }

        protected override int Calculate(int a, int b)
        {
            return a - b;
        }
    }
}