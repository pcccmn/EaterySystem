using CustomerOrderSystem_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
       
        // GET api/<OrderController>/5/5
        [HttpGet("{restaurantId}/{tableNumber}")]
        public IActionResult Get(int restaurantId, int tableNumber)
        {
            var orders = db.Orders
                .Where(x => x.RestaurantId == restaurantId && x.TableNumber == tableNumber)
                .Include(x=>x.Food)
                .Include(x=>x.Restaurant)
                ;

            return Ok(JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        // POST api/<OrderController>/order/new
        [HttpPost("new")]
        public IActionResult NewOrder(JObject data)
        {
            try
            {
                var objRestaurantId = data["restaurant_id"];
                var objTableNumber = data["table_number"];
                var objFoods = data["foods"];

                int restaurantId = 0;
                int tableNumber = 0;

                if (objRestaurantId == null)
                    return BadRequest("Invalid restaurantId");
                else if (!int.TryParse(objRestaurantId.ToString(), out restaurantId))
                    return BadRequest("Invalid restaurantId");

                if (objTableNumber == null)
                    return BadRequest("Invalid tableNumber");
                else if (!int.TryParse(objTableNumber.ToString(), out tableNumber))
                    return BadRequest("Invalid tableNumber");

                List<Dictionary<string, object>> listFoods;

                if (objFoods == null || objFoods.ToString().Length == 0)
                    return BadRequest("Invalid foods");
                else
                    try
                    {
                        listFoods = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(objFoods.ToString())!;                        
                    }
                    catch (JsonSerializationException)
                    {
                        return BadRequest("Invalid foods. Deserialization error");
                    }

                if (listFoods.Count == 0)
                    return BadRequest("Invalid foods. listFood.Count == 0");

                var orders = new List<Order>();

                listFoods.ForEach(x =>
                {
                    var foodId = int.Parse(x["food_id"].ToString());
                    var quantity = int.Parse(x["quantity"].ToString());

                    orders.Add(new Order
                    {
                        RestaurantId = restaurantId,
                        TableNumber = tableNumber,
                        FoodId = foodId,
                        Quantity = quantity
                    });
                });

                db.Orders.AddRange(orders);

                db.SaveChanges();

                return Ok(JsonConvert.SerializeObject(listFoods, Formatting.Indented));
            }
            catch (Exception)
            {
                return BadRequest("Failed at NewOrder");
            }
        }
      
    }
}

public class TestModel
{
    public RefRestaurant refRestaurant { get; set; }
}
