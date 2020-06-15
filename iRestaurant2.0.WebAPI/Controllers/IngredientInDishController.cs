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
    public class IngredientInDishController : ApiController
    {
        public DishService dishService = new DishService();
        
        public IHttpActionResult DeleteIngredient(int id)
        {
            if (!dishService.DeleteIngredientInDish(id))
                return InternalServerError();

            return Ok();
        }
    }
}
