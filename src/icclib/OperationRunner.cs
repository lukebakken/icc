namespace icclib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OperationRunner
    {
        private readonly IEnumerable<int> initialSet;

        public OperationRunner(IEnumerable<int> initialSet)
        {
            if (initialSet == null)
            {
                throw new ArgumentNullException("initialSet");
            }

            this.initialSet = initialSet;
        }

        public IEnumerable<OpResult> Run()
        {
            return RunOperations(initialSet).Where(r => r.Value >= 1).OrderBy(r => r.Value);
        }

        private IEnumerable<OpResult> RunOperations(IEnumerable<int> set)
        {
            if (set.Count() == 1)
            {
                var value = set.First();
                yield return new OpResult(value, value.ToString());
            }
            else
            {
                foreach (var pair in set.PairwiseSets())
                {
                    var p0 = pair.First();
                    var p1 = pair.Last();
                    foreach (var p0r in RunOperations(p0))
                    {
                        foreach (var p1r in RunOperations(p1))
                        {
                            var add = new Addition(p0r, p1r);
                            yield return add.Result;

                            var sub1 = new Subtraction(p0r, p1r);
                            yield return sub1.Result;

                            var sub2 = new Subtraction(p1r, p0r);
                            yield return sub2.Result;

                            var mult = new Multiplication(p0r, p1r);
                            yield return mult.Result;

                            /*
                            if (p1r.Value != 0)
                            {
                                var div = new Division(p0r, p1r);
                                yield return div.Result;
                            }

                            if (p0r.Value != 0)
                            {
                                var div = new Division(p1r, p0r);
                                yield return div.Result;
                            }
                            */
                        }
                    }
                }
            }
        }
    }
}
