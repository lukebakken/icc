namespace icc
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using icclib;
    using Microsoft.SolverFoundation.Common;

    class Program
    {
        static void Main(string[] args)
        {
            uint total = 0;
            var opts = new OperationRunnerOptions(withFactorials: true);

            var inputs = new List<Rational[]>();

            // TODO auto-generate this
            inputs.Add(new Rational[] { 2, 0, 1, 7 });
            inputs.Add(new Rational[] { 12, 70 });
            inputs.Add(new Rational[] { 17, 20 });
            inputs.Add(new Rational[] { 20, 17 });
            inputs.Add(new Rational[] { 20, 71 });
            inputs.Add(new Rational[] { 21, 70 });
            inputs.Add(new Rational[] { 102, 7 });
            inputs.Add(new Rational[] { 120, 7 });
            inputs.Add(new Rational[] { 127, 0 });
            inputs.Add(new Rational[] { 170, 2 });
            inputs.Add(new Rational[] { 172, 0 });
            inputs.Add(new Rational[] { 201, 7 });
            inputs.Add(new Rational[] { 207, 1 });
            inputs.Add(new Rational[] { 271, 0 });
            inputs.Add(new Rational[] { 710, 2 });
            inputs.Add(new Rational[] { 701, 2 });
            inputs.Add(new Rational[] { 712, 0 });
            inputs.Add(new Rational[] { 721, 0 });

            Rational r = Rational.Get(2, 10);
            inputs.Add(new Rational[] { r, 1, 7 });

            r = Rational.Get(1, 10);
            inputs.Add(new Rational[] { 2, r, 7 });

            r = Rational.Get(7, 10);
            inputs.Add(new Rational[] { 2, 1, r });

            var runner = new OperationRunner(inputs, opts);

            string outputFile = Path.GetTempFileName();
            Console.WriteLine("Output: {0}", outputFile);

            using (var sw = new StreamWriter(outputFile))
            {
                foreach (var rslt in runner.Run())
                {
                    ++total;
                    sw.WriteLine("{0} = {1}", rslt.Value, rslt);
                }
            }

            Console.WriteLine("Done! Total: {0}", total);
        }
    }
}
