namespace icclib
{
    using Microsoft.SolverFoundation.Common;

    public abstract class UnaryOperation : Operation
    {
        public UnaryOperation(Rational a) : base(a)
        {
        }

        public UnaryOperation(OpResult a) : base(a)
        {
        }

        protected override string GetRepr(object a, object _b)
        {
            return string.Format("{0}{1}", a, Operator);
        }

        protected override Rational GetValue(Rational a, Rational _b)
        {
            return Calculate(a);
        }

        protected abstract Rational Calculate(Rational a);
    }
}