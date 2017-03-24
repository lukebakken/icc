namespace icclib
{
    using System;
    using Microsoft.SolverFoundation.Common;

    public abstract class UnaryOperation
    {
        private readonly Rational value;
        private readonly string repr;

        public UnaryOperation(Rational a)
        {
            value = Calculate(a);
            repr = Repr(a);
        }

        public UnaryOperation(OpResult a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            value = Calculate(a.Value);
            repr = Repr(a);
        }

        public OpResult Result
        {
            get { return new OpResult(value, repr); }
        }

        public Rational Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return repr;
        }

        protected abstract Rational Calculate(Rational a);
        protected abstract char Operator { get; }

        private string Repr(object a)
        {
            return string.Format("{0}{1}", a, Operator);
        }
    }
}