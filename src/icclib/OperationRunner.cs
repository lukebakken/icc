namespace icclib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OperationRunner
    {
        private readonly IEnumerable<ulong> initialSet;
        private readonly OperationRunnerOptions opts;

        public OperationRunner(IEnumerable<ulong> initialSet, OperationRunnerOptions opts = null)
        {
            if (initialSet == null)
            {
                throw new ArgumentNullException("initialSet");
            }

            this.initialSet = initialSet;

            if (opts == null)
            {
                this.opts = OperationRunnerOptions.Default;
            }
            else
            {
                this.opts = opts;
            }
        }

        public IEnumerable<OpResult> Run()
        {
            return RunOperations(initialSet)
                .Where(r => r.Value.IsInteger() && r.Value >= 1 && r.Value <= 100)
                .OrderBy(r => r.Value);
        }

        private IEnumerable<OpResult> RunOperations(IEnumerable<ulong> set)
        {
            if (set.Count() == 1)
            {
                var value = set.First();
                yield return new OpResult(value, value.ToString());
                if (opts.WithFactorials)
                {
                    var factorial = new Factorial(value);
                    if (factorial.IsAllowed)
                    {
                        yield return factorial.Result;
                    }
                }
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
                            if (opts.WithFactorials)
                            {
                                var factorial = new Factorial(add.Result);
                                if (factorial.IsAllowed)
                                {
                                    yield return factorial.Result;
                                }
                            }

                            var sub1 = new Subtraction(p0r, p1r);
                            yield return sub1.Result;
                            if (opts.WithFactorials)
                            {
                                var factorial = new Factorial(sub1.Result);
                                if (factorial.IsAllowed)
                                {
                                    yield return factorial.Result;
                                }
                            }

                            var sub2 = new Subtraction(p1r, p0r);
                            yield return sub2.Result;
                            if (opts.WithFactorials)
                            {
                                var factorial = new Factorial(sub2.Result);
                                if (factorial.IsAllowed)
                                {
                                    yield return factorial.Result;
                                }
                            }

                            var mult = new Multiplication(p0r, p1r);
                            yield return mult.Result;
                            if (opts.WithFactorials)
                            {
                                var factorial = new Factorial(mult.Result);
                                if (factorial.IsAllowed)
                                {
                                    yield return factorial.Result;
                                }
                            }

                            var div0 = new Division(p0r, p1r);
                            if (div0.IsAllowed)
                            {
                                yield return div0.Result;
                                if (opts.WithFactorials)
                                {
                                    var factorial = new Factorial(div0.Result);
                                    if (factorial.IsAllowed)
                                    {
                                        yield return factorial.Result;
                                    }
                                }
                            }

                            var div1 = new Division(p1r, p0r);
                            if (div1.IsAllowed)
                            {
                                yield return div1.Result;
                                if (opts.WithFactorials)
                                {
                                    var factorial = new Factorial(div1.Result);
                                    if (factorial.IsAllowed)
                                    {
                                        yield return factorial.Result;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
