using System;
using System.Collections.Generic;


namespace P08.MilitaryElite
{
    public interface ICommando
    {
        List<Mission> Missions { get; }

        void CompleteMission(Mission mission);
    }
}
