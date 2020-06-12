using iRestaurant2._0.Data;
using iRestaurant2._0.Models.ChefModels;
using iRestaurant2._0.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iRestaurant2._0.WebAPI.Controllers
{
    [Authorize]
    public class ChefController : ApiController
    {
        public ChefService chefService = new ChefService();
        public IHttpActionResult Get()
        {
            var chefs = chefService.GetChefs();
            return Ok(chefs);
        }
        public IHttpActionResult Get(int id)
        {
            var chefs = chefService.GetChefById(id);
            return Ok(chefs);
        }
        public IHttpActionResult Post(ChefCreate Chef)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!chefService.CreateChef(Chef))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ChefEdit chef)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!chefService.UpdateChef(chef))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {

            if (chefService.DeleteChef(id))
                return InternalServerError();

            return Ok();
        }
    }
}
