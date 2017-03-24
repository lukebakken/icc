namespace icclib
{
    public class Multiplication
    {
        private readonly int value;
        private readonly string repr;

        public Multiplication(int a, int b)
        {
            value = a * b;
            repr = string.Format("({0} x {1})", a, b);
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public override string ToString()
        {
            return repr;
        }
    }
}