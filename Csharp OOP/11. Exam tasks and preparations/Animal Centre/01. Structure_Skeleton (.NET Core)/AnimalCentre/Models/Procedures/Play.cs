﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.Happiness += 12;
            animal.Energy -= 6;
            animal.ProcedureTime -= procedureTime;
            this.procedureHistory.Add(animal);

        }
    }
}