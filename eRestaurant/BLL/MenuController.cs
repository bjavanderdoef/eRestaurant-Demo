using System;
using System.Collections.Generic;
using System.Linq;
using eRestaurant.DAL; // for RestaurantContext
using eRestaurant.Entities.DTOs; // for CategoryWithItems
using eRestaurant.Entities.POCOS; // for MenuItem

namespace eRestaurant.BLL
{
    public class MenuController
    {
        public List<CategoryWithItems> GetRestaurantMenu()
        {
            // We want to access the DAL - using the RestaurantContext - to work with the database.
            // BUT, we want to be careful to ensure any lingering open connections are closed if anything were to go wrong.
            // The using statement helps us with this.
            using (var context = new RestaurantContext())
            {
                // any errors inside this statement block will not be a problem in terms of leaving the database connection open.
                var data = from aCategory in context.MenuCategories
                           orderby aCategory.Description
                           select new CategoryWithItems()
                           {
                               Description = aCategory.Description,
                               MenuItems = (from item in aCategory.Items
                                            orderby item.Description
                                            select new MenuItem()
                                            {
                                                Description = item.Description,
                                                Price = item.CurrentPrice,
                                                Calories = item.Calories,
                                                Comment = item.Comment
                                            }).ToList()
                           };
                return data.ToList();
            }
        }
    }
}
