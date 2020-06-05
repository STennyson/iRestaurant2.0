using iRestaurant2._0.Models.Signature_Dish;
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
    public class Signature_DishController : ApiController
    {
        private Signature_DishService CreateSignature_DishService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var dishService = new Signature_DishService(/*userId*/);
            return dishService;
        }

        public IHttpActionResult Get()
        {
            Signature_DishService dishService = CreateSignature_DishService();
            var dishes = dishService.GetSignature_Dishes();
            return Ok(dishes);
        }

        public IHttpActionResult Get(int id)
        {
            Signature_DishService dishService = CreateSignature_DishService();
            var dish = dishService.GetSignature_DishById(id);
            return Ok(dish);
        }

        public IHttpActionResult Post(Signature_DishCreate dish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSignature_DishService();

            if (!service.CreateSignature_Dish(dish))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(Signature_DishEdit dish)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSignature_DishService();

            if (!service.UpdateSignature_Dish(dish))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSignature_DishService();

            if (!service.DeleteSignature_Dish(id))
                return InternalServerError();

            return Ok();
        }
    }
}
