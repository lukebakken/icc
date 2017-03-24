namespace icclib
{
    using Microsoft.SolverFoundation.Common;

    public class Subtraction : BinaryOperation
    {
        public Subtraction(Rational a, Rational b) : base(a, b) { }

        public Subtraction(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '-'; }
        }

        protected override Rational Calculate(Rational a, Rational b)
        {
            return a - b;
        }
    }
}