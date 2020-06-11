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
        public bool CreateChef(ChefCreate model)
        {
            //var dish = DishNameReference(model.DishID);
            var entity =
                new Chef()
                {
                    Full_Name = model.Full_Name,
                    Speciality = model.Speciality,
                    //DishID = dish.DishID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Chefs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public Dish DishNameReference(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == id /* && e.UserID == _userId*/);
                return entity;
            }
            return null;
        }
        public IEnumerable<ChefListItem> GetChefs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Chefs
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ChefListItem
                                {
                                    ChefID = e.ChefID,
                                    Full_Name = e.Full_Name,
                                    Speciality = e.Speciality,
                                    //SignatureDish = e.SignatureDish
                                }
                        );

                return query.ToArray();
            }
        }
        public ChefDetail GetChefById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Chefs
                        .Single(e => e.ChefID == id /*&& e.OwnerId == _userId*/);
                return
                    new ChefDetail
                    {
                        ChefID = entity.ChefID,
                        Full_Name = entity.Full_Name,
                        Speciality = entity.Speciality,
                        //SignatureDish = entity.SignatureDish
                    };
            }
        }
        public bool UpdateChef(ChefEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Chefs
                        .Single(e => e.ChefID == model.ChefID /*&& e.OwnerId == _userId*/);

                entity.ChefID = model.ChefID;
                entity.Full_Name = model.Full_Name;
                entity.Speciality = model.Speciality;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteChef(int chefId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Chefs
                        .Single(e => e.ChefID == chefId /*&& e.OwnerId == _userId*/);

                ctx.Chefs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
