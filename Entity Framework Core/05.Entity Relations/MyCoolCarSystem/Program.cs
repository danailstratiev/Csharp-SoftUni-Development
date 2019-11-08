using Microsoft.EntityFrameworkCore;
using MyCoolCarSystem.Data;
using MyCoolCarSystem.Data.Models;
using System;
using System.Linq;

namespace MyCoolCarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CarDbContext())
            {
                db.Database.Migrate();

                var customer = db.Customers.FirstOrDefault();

                customer.Address = new Address
                {
                    Text = "Tintiava 15",
                    Town = "Sofia"
                };

                db.SaveChanges();
            }
        }
    }
}
