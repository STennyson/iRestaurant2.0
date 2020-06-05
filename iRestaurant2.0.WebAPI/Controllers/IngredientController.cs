using iRestaurant2._0.Models.IngredientModels;
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
    public class IngredientController : ApiController
    {
        private IngredientService CreateIngredientService()
        {
            var ingredientService = new IngredientService();
            return ingredientService;

        }
        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }

        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIngredientService();

            if (!service.CreateIngredient(ingredient))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredient = ingredientService.GetIngredientByID(id);
            return Ok(ingredient);
        }
        public IHttpActionResult Put(IngredientEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIngredientService();

            if (!service.UpdateIngredient(note))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateIngredientService();

            if (!service.DeleteIngredient(id))
                return InternalServerError();

            return Ok();
        }
    }
}

