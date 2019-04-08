namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Utilities;
    using SimpleSnake.GameObjects.Foods;
    using SimpleSnake.Core;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            var wall = new Wall(60, 20);
            var snake = new Snake(wall);
            var engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}
