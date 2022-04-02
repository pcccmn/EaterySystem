using CustomerOrderSystem_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<MenuController>
        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            var menus = db.Menus;

            return menus;
        }

        // GET api/<MenuController>/5
        [HttpGet("{restaurantCode}")]
        public IEnumerable<Menu> Get(string restaurantCode)
        {
            var menus = db.Menus.Where(x => x.Restaurant != null && x.Restaurant.Code == restaurantCode);

            return menus;
        }

        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
