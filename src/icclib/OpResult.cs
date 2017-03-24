namespace icclib
{
    using System;

    public class OpResult
    {
        private readonly int value;
        private readonly string repr;

        public OpResult(int value, string repr)
        {
            this.value = value;

            if (string.IsNullOrWhiteSpace(repr))
            {
                throw new ArgumentNullException("repr");
            }

            this.repr = repr;
        }

        public int Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return repr;
        }
    }
}