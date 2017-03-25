namespace icclib
{
    using System;
    using Microsoft.SolverFoundation.Common;

    public abstract class BinaryOperation : Operation
    {
        public BinaryOperation(Rational a, Rational b)
            : base(a, b)
        {
        }

        public BinaryOperation(OpResult a, OpResult b)
            : base(a, b)
        {
            if (b == null)
            {
                throw new ArgumentNullException("b");
            }
        }

        protected override bool GetIsAllowed(Rational _a, Rational _b)
        {
            return true;
        }

        protected override string GetRepr(object a, object b)
        {
            return string.Format("({0} {1} {2})", a, Operator, b);
        }

        protected override Rational GetValue(Rational a, Rational b)
        {
            return Calculate(a, b);
        }

        protected abstract Rational Calculate(Rational a, Rational b);
    }
}