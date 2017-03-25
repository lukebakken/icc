﻿namespace icclib
{
    using System;
    using Microsoft.SolverFoundation.Common;

    public class Factorial : UnaryOperation
    {
        public static readonly Rational[] Factorials =
        {
            1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600,
            6227020800, 87178291200, 1307674368000, 20922789888000, 355687428096000,
            6402373705728000, 121645100408832000, 2432902008176640000 //,
            /*
            51090942171709440000, 1124000727777607680000, 25852016738884976640000,
            620448401733239439360000, 15511210043330985984000000, 403291461126605635584000000,
            10888869450418352160768000000, 304888344611713860501504000000, 8841761993739701954543616000000,
            265252859812191058636308480000000, 8222838654177922817725562880000000, 263130836933693530167218012160000000,
            8683317618811886495518194401280000000, 295232799039604140847618609643520000000, 10333147966386144929666651337523200000000,
            371993326789901217467999448150835200000000, 13763753091226345046315979581580902400000000, 523022617466601111760007224100074291200000000,
            20397882081197443358640281739902897356800000000, 815915283247897734345611269596115894272000000000
            */
        };
        private static readonly int max = Factorials.Length - 1;
        private static readonly string err_max = string.Format("factorials only supported on integer values from 0 to {0}", max);

        public Factorial(Rational a) : base(a)
        {
        }

        public Factorial(OpResult a) : base(a)
        {
        }

        protected override char Operator
        {
            get { return '!'; }
        }

        protected override Rational Calculate(Rational a)
        {
            if (IsAllowed)
            {
                return Factorials[(int)a];
            }
            else
            {
                return default(Rational);
            }
        }

        protected override bool GetIsAllowed(Rational a, Rational b)
        {
            return a.IsInteger() && a >= 0 && a <= max;
        }
    }
}