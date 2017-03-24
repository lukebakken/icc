namespace Test
{
    using System.Collections.Generic;
    using System.Linq;
    using icclib;
    using Xunit;

    public class SetTests
    {
        [Fact]
        public void PairwiseSetsAreGeneratedCorrectly()
        {
            var e0 = new int[][] { new[] { 2, 0, 1 }, new[] { 7 } };
            var e1 = new int[][] { new[] { 2, 0, 7 }, new[] { 1 } };
            var e2 = new int[][] { new[] { 2, 0 }, new[] { 1, 7 } };
            var e3 = new int[][] { new[] { 2, 1, 7 }, new[] { 0 } };
            var e4 = new int[][] { new[] { 2, 1 }, new[] { 0, 7 } };
            var e5 = new int[][] { new[] { 2, 7 }, new[] { 0, 1 } };
            var e6 = new int[][] { new[] { 2 }, new[] { 0, 1, 7 } };
            var expected = new List<int[][]>
            {
                e0, e1, e2, e3, e4, e5, e6
            };

            var ary = new int[] { 2, 0, 1, 7 };

            var p = ary.PairwiseSets();

            Assert.Equal(7, p.Count());

            foreach (var i in p)
            {
                Assert.Equal(2, i.Count());
                var i0 = i.First();
                var i1 = i.Last();
                bool found = false;
                foreach (var exp in expected)
                {
                    var exp0 = exp[0];
                    var exp1 = exp[1];
                    found = i0.SequenceEqual(exp0) && i1.SequenceEqual(exp1);
                    if (found)
                    {
                        break;
                    }
                }

                string repr0 = string.Join(",", i0);
                string repr1 = string.Join(",", i1);
                string errMsg = string.Format("did not meet expectation for pair {0}, {1}", repr0, repr1);
                Assert.True(found, errMsg);
            }
        }
    }
}
