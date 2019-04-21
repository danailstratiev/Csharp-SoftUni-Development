namespace MortalEngines
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MortalEngines.IO;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}