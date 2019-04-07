namespace P07.InfernoInfinity.Gems.ClarityTypes
{
    public abstract class ClarityType
    {
        protected ClarityType(int statAccelerator)
        {
            this.StatAccelerator = statAccelerator;
        }

        public int StatAccelerator { get; private set; }
    }
}
