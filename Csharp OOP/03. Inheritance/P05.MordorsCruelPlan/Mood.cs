namespace P05.MordorsCruelPlan
{
    using System;

    public abstract class Mood
    {
        protected Mood(int happinesPints)
        {
            this.HappinesPints = happinesPints;
        }

        public int HappinesPints { get;protected set; }

        public override string ToString()
        {
            return $"{this.HappinesPints}" + Environment.NewLine + $"{this.GetType().Name}";
        }
    }
}
