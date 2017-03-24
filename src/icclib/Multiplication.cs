namespace icclib
{
    using Microsoft.SolverFoundation.Common;

    public class Multiplication : BinaryOperation
    {
        public Multiplication(Rational a, Rational b) : base(a, b) { }

        public Multiplication(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '\u00d7'; }
        }

        protected override Rational Calculate(Rational a, Rational b)
        {
            return a * b;
        }
    }
}