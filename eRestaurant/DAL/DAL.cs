using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.DAL
{
    // : DbContext means that my class inherits from the DbContext class
    internal class RestaurantContex : DbContext
    {
        // : base(string) is the constructor of the DbContext class that I call before running the body of my own construction.
        // Hooking up constructors to call other constructors is called "Constructor Chaining"
        public RestaurantContex() : base("name=EatIn") { }

        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
