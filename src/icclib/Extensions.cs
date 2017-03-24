namespace icclib
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<IEnumerable<T>>> PairwiseSets<T>(this IEnumerable<T> set)
        {
            foreach (var p in Pairs(set))
            {
                // NB: we know each p is really a 2-tuple (pair) posing as IEnumerable
                var p0 = p.First();
                var p1 = p.Last();
                if (p0.Count() > 0 && p1.Count() > 0)
                {
                    yield return new IEnumerable<T>[2] { p0, p1 };
                }
            }
        }

        private static IEnumerable<IEnumerable<IEnumerable<T>>> Pairs<T>(IEnumerable<T> s)
        {
            int count = s.Count();
            if (count == 1)
            {
                yield return new IEnumerable<T>[2] { s, Enumerable.Empty<T>() };
            }
            else
            {
                IEnumerable<T> first_part = s.Take(count - 1);
                IEnumerable<T> last_part = s.Skip(count - 1);
                foreach (var p in Pairs(first_part))
                {
                    // NB: we know each p is really a 2-tuple (pair) posing as IEnumerable
                    var p0 = p.First();
                    var p1 = p.Last();
                    yield return new IEnumerable<T>[2] { p0.Concat(last_part), p1 };
                    yield return new IEnumerable<T>[2] { p0, p1.Concat(last_part) };
                }
            }
        }
    }
}
