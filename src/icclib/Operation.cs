namespace icclib
{
    using System;
    using Microsoft.SolverFoundation.Common;

    public abstract class Operation
    {
        private readonly bool isAllowed;
        private readonly string repr;
        private readonly Rational value;

        public Operation(Rational a)
            : this(a, default(Rational))
        {
        }

        public Operation(Rational a, Rational b)
        {
            isAllowed = GetIsAllowed(a, b);
            repr = GetRepr(a, b);
            value = GetValue(a, b);
        }

        public Operation(OpResult a)
            : this(a, default(OpResult))
        {
        }

        public Operation(OpResult a, OpResult b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            Rational bVal = default(Rational);
            if (b != null)
            {
                bVal = b.Value;
            }

            isAllowed = GetIsAllowed(a.Value, bVal);
            repr = GetRepr(a, b);
            value = GetValue(a.Value, bVal);
        }

        public bool IsAllowed
        {
            get { return isAllowed; }
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

        protected abstract char Operator { get; }
        protected abstract bool GetIsAllowed(Rational a, Rational b);
        protected abstract string GetRepr(object a, object b);
        protected abstract Rational GetValue(Rational a, Rational b);
    }
}