using iRestaurant2._0.Data;
using iRestaurant2._0.Models.DishModels;
using iRestaurant2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace iRestaurant2._0.WebAPI.Controllers
{
        [Authorize]
    public class DishController : ApiController
    {
        public DishService dishService = new DishService();
        
        public IHttpActionResult Get()
        {
            var dishes = dishService.GetDishes();
            return Ok(dishes);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            Dish dish = await _context.Dishes.FindAsync(id);
            if (dish != null)
            {
                var dish1 = dishService.GetDishById(id);
                return Ok(dish1);
            }
            return NotFound();

        }


        public IHttpActionResult Post(DishCreate dish)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!dishService.CreateDish(dish))
                return InternalServerError();


            return Ok();
        }

        public IHttpActionResult Put(DishEdit dish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!dishService.UpdateDish(dish))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {

            if (!dishService.DeleteDish(id))
                return InternalServerError();

            return Ok();
        }
        
    }
}
