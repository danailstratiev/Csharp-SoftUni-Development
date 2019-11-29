﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public abstract class GiftBase
    {
        protected string name;
        protected int price;
        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public abstract int CalculateTotalPrice();
    }
}
