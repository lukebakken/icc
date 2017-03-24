namespace icc
{
    using System;
    using icclib;

    class Program
    {
        static void Main(string[] args)
        {
            var a = new ulong[] { 2, 0, 1, 7 };
            var runner = new OperationRunner(a);
            foreach (var r in runner.Run())
            {
                Console.WriteLine("{0} = {1}", r.Value, r);
            }
        }
    }
}
