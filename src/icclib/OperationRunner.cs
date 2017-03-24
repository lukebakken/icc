namespace icclib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OperationRunner
    {
        private readonly IEnumerable<int> set;

        public OperationRunner(IEnumerable<int> set)
        {
            if (set == null)
            {
                throw new ArgumentNullException("set");
            }

            this.set = set;
        }

        public IEnumerable<string> Run()
        {
            return Enumerable.Empty<string>();
        }
    }
}
