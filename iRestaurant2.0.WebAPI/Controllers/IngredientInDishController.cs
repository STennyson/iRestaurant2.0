using iRestaurant2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iRestaurant2._0.WebAPI.Controllers
{
    public class IngredientInDishController : ApiController
    {
        [Authorize]
        private DishService CreateDishService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var dishService = new DishService(/*userId*/);
            return dishService;
        }
        public IHttpActionResult DeleteIngredient(int id)
        {
            var service = CreateDishService();

            if (!service.DeleteIngredientInDish(id))
                return InternalServerError();

            return Ok();
        }
    }
}
