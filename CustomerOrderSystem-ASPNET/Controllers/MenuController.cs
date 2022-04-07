using CustomerOrderSystem_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerOrderSystem_ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private order_systemContext db;

        public MenuController(order_systemContext context)
        {
            this.db = context;
        }

        // GET api/<MenuController>/restaurantId
        [HttpGet("{restaurantId}")]
        public IActionResult Get(int restaurantId)
        {
            var menus = db.Menus
                .Include(x => x.Food)
                .Include(x => x.Restaurant)
                .Where(x => x.RestaurantId == restaurantId)
                ;

            return Ok(JsonConvert.SerializeObject(menus, Formatting.Indented));
        }
    }
}
