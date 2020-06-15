using iRestaurant2._0.Data;
using iRestaurant2._0.Models.ChefModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Services
{
    public class ChefService
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateChef(ChefCreate model)
        {
            var entity =
                new Chef()
                {
                    Full_Name = model.Full_Name,
                    Speciality = model.Speciality,
                };
            _context.Chefs.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<ChefListItem> GetChefs()
        {
            var chefEntities = _context.Chefs.ToList();
            var chefList = chefEntities.Select(c => new ChefListItem
            {
                ChefID = c.ChefID,
                Full_Name = c.Full_Name,
                Speciality = c.Speciality
            }).ToList();

            return chefList;
        }

        public ChefDetail GetChefById(int id)
        {
            var chefEntity = _context.Chefs.Find(id);
            if (chefEntity == null)
                return null;

            var detail = new ChefDetail
            {
                ChefID = chefEntity.ChefID,
                Full_Name = chefEntity.Full_Name,
                Speciality = chefEntity.Speciality
            };
            return detail;
        }
        public bool UpdateChef(ChefEdit model)
        {
            var chefEntity = _context.Chefs.Find(model.ChefID);
            if (chefEntity == null)
                return false;

            chefEntity.ChefID = model.ChefID;
            chefEntity.Full_Name = model.Full_Name;
            chefEntity.Speciality = model.Speciality;

            return _context.SaveChanges() == 1;
        }
        public bool DeleteChef(int chefId)
        {
            var chefEntity = _context.Chefs.Find(chefId);
            if (chefEntity == null)
                return false;

            _context.Chefs.Remove(chefEntity);

            return _context.SaveChanges() == 1;
        }
    }
}
