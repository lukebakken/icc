namespace icclib
{
    using System;

    public abstract class BinaryOperation
    {
        private readonly int value;
        private readonly string repr;

        public BinaryOperation(int a, int b)
        {
            value = Calculate(a, b);
            repr = Repr(a, b);
        }

        public BinaryOperation(OpResult a, OpResult b)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            if (b == null)
            {
                throw new ArgumentNullException("b");
            }

            value = Calculate(a.Value, b.Value);
            repr = Repr(a, b);
        }

        public OpResult Result
        {
            get { return new OpResult(value, repr); }
        }

        public int Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return repr;
        }

        protected abstract int Calculate(int a, int b);
        protected abstract char Operator { get; }

        private string Repr(object a, object b)
        {
            return string.Format("({0} {1} {2})", a, Operator, b);
        }
    }
}