namespace icclib
{
    using Microsoft.SolverFoundation.Common;

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

        protected override Rational Calculate(Rational a, Rational b)
        {
            return a + b;
        }
    }
}