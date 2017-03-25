namespace icclib
{
    public class OperationRunnerOptions
    {
        public static readonly OperationRunnerOptions Default = new OperationRunnerOptions(withFactorials: false);

        private readonly bool withFactorials;

        public OperationRunnerOptions(bool withFactorials)
        {
            this.withFactorials = withFactorials;
        }

        public bool WithFactorials
        {
            get { return withFactorials; }
        }
    }
}
