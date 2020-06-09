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
    public class DishController : ApiController
    {
        [Authorize]
        private DishService CreateDishService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var dishService = new DishService(/*userId*/);
            return dishService;
        }

        public IHttpActionResult Get()
        {
            DishService dishService = CreateDishService();
            var dishes = dishService.GetDishes();
            return Ok(dishes);
        }

        public IHttpActionResult Get(int id)
        {
            DishService dishService = CreateDishService();
            var dish = dishService.GetDishById(id);
            return Ok(dish);
        }


        public IHttpActionResult Post(DishCreate dish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDishService();

            if (!service.CreateDish(dish))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DishEdit dish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDishService();

            if (!service.UpdateDish(dish))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateDishService();

            if (!service.DeleteDish(id))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var service = CreateDishService();

            if (!service.DeleteIngredientInDish(id))
                return InternalServerError();

            return Ok();
        }
    }
}
