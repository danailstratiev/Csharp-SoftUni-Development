using SoftUniRestaurant.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class TableFactory
    {
        public Table CreateTable(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                default:
                    return null;
            }
        }
    }
}
