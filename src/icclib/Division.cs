namespace icclib
{
    public class Division : BinaryOperation
    {
        public Division(int a, int b) : base(a, b) { }

        public Division(OpResult a, OpResult b) : base(a, b) { }

        protected override char Operator
        {
            get { return '\u00f7'; }
        }

        protected override int Calculate(int a, int b)
        {
            return a / b;
        }
    }
}