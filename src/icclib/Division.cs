namespace icclib
{
    using Microsoft.SolverFoundation.Common;

    public class Division : BinaryOperation
    {
        public Division(Rational a, Rational b) : base(a, b) { }

        public Division(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '\u00f7'; }
        }

        protected override Rational Calculate(Rational a, Rational b)
        {
            return a / b;
        }

        protected override bool GetIsAllowed(Rational a, Rational b)
        {
            return b != 0;
        }
    }
}