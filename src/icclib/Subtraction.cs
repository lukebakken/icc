﻿namespace icclib
{
    public class Subtraction
    {
        private readonly int value;
        private readonly string repr;

        public Subtraction(int a, int b)
        {
            value = a - b;
            repr = string.Format("({0} - {1})", a, b);
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