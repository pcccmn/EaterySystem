using CustomerOrderSystem_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerOrderSystem_ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private order_systemContext db;

        public OrderController(order_systemContext orderSystemContext)
        {
            this.db = orderSystemContext;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{restaurantCode}/{tableNumber}")]
        public IEnumerable<Order> Get(string restaurantCode, int tableNumber)
        {
            var orders = db.Orders.Where(x => x.Restaurant != null && x.Restaurant.Code == restaurantCode && x.TableNumber == tableNumber).ToList();

            return orders;
        }

        // POST api/<OrderController>
        [HttpPost("{restaurantCode}/{tableNumber}/{foods}")]
        public async Task<ActionResult<IEnumerable<Order>>> Post(string restaurantCode, int tableNumber, int [] foods) // foodsOrdered must be a json
        {
            if (restaurantCode == null || restaurantCode.Length == 0)
                return BadRequest("Invalid Restaurant");

            if (foods == null || foods.Length == 0)
                return BadRequest("No Foods Ordered");

            RefRestaurant? restaurant = await db.RefRestaurants.FirstOrDefaultAsync(x => x.Code == restaurantCode);
            if (restaurant == null)
            {
                return BadRequest($"Restaurant not found with Code={restaurantCode}");
            }

            foreach (var foodId in foods)
            {
                var food = await db.RefFoods.FirstOrDefaultAsync(x => x.Id == foodId);

                if (food == null)
                    return BadRequest($"Food not found. foodId={foodId}");

                var newOrder = new Order() { Restaurant = restaurant, TableNumber = tableNumber, Food = food };
                db.Add(newOrder);
            }

            await db.SaveChangesAsync();

            return Ok(await db.Orders.ToListAsync());

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
