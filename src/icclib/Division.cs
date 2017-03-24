namespace icclib
{
    public class Division
    {
        private readonly int value;
        private readonly string repr;

        public Division(int a, int b)
        {
            value = a / b; // TODO FIXME not exact representation of value
            repr = string.Format("({0} / {1})", a, b);
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