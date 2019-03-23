using System;
using System.Collections.Generic;
using System.Text;

namespace P05.MordorsCruelPlan
{
   public abstract class Food
    {
        protected Food(int points)
        {
            this.Points = points;
        }

        public int Points { get;protected set; }
    }
}
