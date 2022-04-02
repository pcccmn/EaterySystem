using System;
using System.Collections.Generic;

namespace CustomerOrderSystem_ASPNET.Models
{
    public partial class RefFood
    {
        public RefFood()
        {
            Menus = new HashSet<Menu>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
