using iRestaurant2._0.Models.ChefModels;
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
    public class ChefController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            ChefService ChefService = CreateChefService();
            var chefs = ChefService.GetChefs();
            return Ok(chefs);
        }
        public IHttpActionResult Post(ChefCreate Chef)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateChefService();

            if (!service.CreateChef(Chef))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ChefEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateChefService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateChefService();

            if (!service.DeleteChef(id))
                return InternalServerError();

            return Ok();
        }

        private ChefService CreateChefService()
        {
            //var userId = Guid.Parse(User.Identity.GetChefId());
            var ChefService = new ChefService();
            return ChefService;
        }
    }
}
