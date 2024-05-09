using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodToOrderAppWPF;
using FoodToOrder_WebAPI.Repositories;

namespace FoodToOrder_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurant repo;

        public RestaurantsController(IRestaurant repo)
        {
            this.repo = repo;
        }
        //Here->
        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurant()
        {
            return repo.GetRestaurants().ToList();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = repo.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        //// PUT: api/Restaurants/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {


            repo.UpdateRestaurant(id, restaurant);
            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            repo.InsertRestaurant(restaurant);
            repo.save();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        //// DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {

            repo.DeleteRestaurant(id);
            repo.save();
            return NoContent();
        }
    }
}
