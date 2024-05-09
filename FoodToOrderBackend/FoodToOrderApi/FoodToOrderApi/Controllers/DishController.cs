using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodToOrderDB;
using FoodToOrderApi.Service;

namespace FoodToOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService service;

        public DishController(IDishService service)
        {
            this.service = service;
        }

        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            return service.GetDishes();
        }

        // GET: api/Dish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(int id)
        {
            var dish =  service.GetDishByID(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        // PUT: api/Dish/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(string id, Dish dish)
        {
            service.UpdateDish(dish);
            service.Save();

            return NoContent(); 
        }

        // POST: api/Dish
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            service.AddDish(dish);
            service.Save();

            return CreatedAtAction("GetDish", new { id = dish.id }, dish);
        }

        // DELETE: api/Dish/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
           service.DeleteDish(id);
            service.Save();

            return NoContent();
        }

        //private bool DishExists(string id)
        //{
        //    return service.Dishes.Any(e => e.id == id);
        //}
    }
}
