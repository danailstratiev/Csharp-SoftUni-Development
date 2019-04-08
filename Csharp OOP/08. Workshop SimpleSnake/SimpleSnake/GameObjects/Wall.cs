namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            : base (leftX, topY)
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(topY - 1);

            this.SetVerticalLine(0);
            this.SetVerticalLine(leftX);
        }

        public bool IsPointOfWall(Point snake)
        {
            // check borders
            return snake.LeftX == 0 || snake.TopY == 0 || 
                snake.LeftX == this.LeftX || snake.TopY == this.TopY - 1;
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
