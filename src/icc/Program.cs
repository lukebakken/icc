namespace icc
{
    using System;
    using icclib;

    class Program
    {
        static void Main(string[] args)
        {
            uint total = 0;
            var a = new ulong[] { 2, 0, 1, 7 };
            var opts = new OperationRunnerOptions(withFactorials: true);
            var runner = new OperationRunner(a, opts);
            foreach (var r in runner.Run())
            {
                ++total;
                Console.WriteLine("{0} = {1}", r.Value, r);
            }
            Console.WriteLine("Total: {0}", total);
        }
    }
}
