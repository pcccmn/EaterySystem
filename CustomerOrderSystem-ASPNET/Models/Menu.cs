using System;
using System.Collections.Generic;

namespace CustomerOrderSystem_ASPNET.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public int? RestaurantId { get; set; }
        public int? FoodId { get; set; }
        public double? Price { get; set; }

        public virtual RefFood? Food { get; set; }
        public virtual RefRestaurant? Restaurant { get; set; }
    }
}
