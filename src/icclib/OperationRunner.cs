namespace icclib
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.SolverFoundation.Common;

    public class OperationRunner
    {
        private readonly IEnumerable<IEnumerable<Rational>> initialSets;
        private readonly OperationRunnerOptions opts;

        public OperationRunner(IEnumerable<IEnumerable<Rational>> initialSets, OperationRunnerOptions opts = null)
        {
            if (initialSets == null)
            {
                throw new ArgumentNullException("initialSet");
            }

            this.initialSets = initialSets;

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
            var bag = new ConcurrentBag<OpResult>();

            Parallel.ForEach(initialSets, (set) =>
            {
                foreach (OpResult r in RunOperations(set).Where(r => r.Value.IsInteger() && r.Value >= 1 && r.Value <= 100))
                {
                    bag.Add(r);
                }
            });

            return bag.OrderBy(opr => opr.Value);
        }

        private IEnumerable<OpResult> RunOperations(IEnumerable<Rational> set)
        {
            if (set.Count() == 1)
            {
                var value = set.First();
                yield return new OpResult(value, value.ToDouble().ToString());
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
