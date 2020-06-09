using iRestaurant2._0.Data;
using iRestaurant2._0.Models.Signature_DishModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Services
{
    public class Signature_DishService
    {
        //private readonly Guid _userId;

        //public DishService(Guid userId)
        //{
        // _userId = userId;
        //}
        public bool CreateSignature_Dish(Signature_DishCreate model)
        {
            var entity =
                new Signature_Dish()
                {
                    Name = model.Name,
                    IngredientsInDish = model.IngredientsInDish,
                    ChefID = model.ChefID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Signature_Dishes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Signature_DishListItem> GetSignature_Dishes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Signature_Dishes
                        //.Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new Signature_DishListItem
                                {
                                    DishID = e.DishID,
                                    Name = e.Name,
                                    Chef = e.Chef
                                }
                        );

                return query.ToArray();
            }
        }

        public Signature_DishDetail GetSignature_DishById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Signature_Dishes
                        .Single(e => e.DishID == id /* && e.UserID == _userId*/);
                return
                    new Signature_DishDetail
                    {
                        DishID = entity.DishID,
                        Name = entity.Name,
                        Chef = entity.Chef,
                        IngredientsInDish = entity.IngredientsInDish


                    };
            }
        }
        public bool UpdateSignature_Dish(Signature_DishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Signature_Dishes
                        .Single(e => e.DishID == model.DishID /*&& e.UserID == _userId*/);

                entity.Name = model.Name;
                entity.IngredientsInDish = model.IngredientsInDish;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSignature_Dish(int dishId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == dishId /*&& e.UserID == _userId*/);

                ctx.Dishes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
