using iRestaurant2._0.Models.DishModels;
using iRestaurant2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public IHttpActionResult Get(int id)
        {
            var dish = dishService.GetDishById(id);
            return Ok(dish);
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
