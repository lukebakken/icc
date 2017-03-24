namespace icclib
{
    using System;
    using Microsoft.SolverFoundation.Common;

    public class OpResult
    {
        private readonly Rational value;
        private readonly string repr;

        public OpResult(Rational value, string repr)
        {
            this.value = value;

            if (string.IsNullOrWhiteSpace(repr))
            {
                throw new ArgumentNullException("repr");
            }

            this.repr = repr;
        }

        public Rational Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return repr;
        }
    }
}