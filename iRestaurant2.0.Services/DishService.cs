using iRestaurant2._0.Data;
using iRestaurant2._0.Models.DishModels;
using iRestaurant2._0.Models.IngredientInDishModels;
using iRestaurant2._0.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Services
{
    public class DishService
    {
        //private readonly Guid _userId;

        //public DishService(Guid userId)
        //{
        // _userId = userId;
        //}
        public bool CreateDish(DishCreate model)
        {
            var entity =
                new Dish()
                {
                    Name = model.Name,
                    //IngredientsInDish = model.IngredientsInDish,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dishes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateIngredientInDish(IngredientInDishCreate model)
        {
            var entity =
                new IngredientInDish()
                {
                    DishID = model.DishID,
                    IngredientID = model.IngredientID,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IngredientsInDish.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteIngredientInDish(int dishId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .IngredientsInDish
                        .Single(e => e.DishID == dishId /*&& e.UserID == _userId*/);

                ctx.IngredientsInDish.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DishListItem> GetDishes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Dishes
                        //.Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new DishListItem
                                {
                                    DishID = e.DishID,
                                    Name = e.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<IngredientListItem> GetIngredientsInDish(int dishID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IngredientsInDish
                        .Where(e => e.DishID == dishID)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    Name = e.Ingredient.Name,
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<DishListItem> GetDishesByIngredient(int ingredientID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IngredientsInDish
                        .Where(e => e.IngredientID == ingredientID)
                        .Select(
                            e =>
                                new DishListItem
                                {
                                    Name = e.Dish.Name,
                                }
                        );

                return query.ToArray();
            }
        }

        public DishDetail GetDishById(int id)
        {
            

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == id /* && e.UserID == _userId*/);
                return
                    new DishDetail
                    {
                        DishID = entity.DishID,
                        Name = entity.Name,
                        IngredientsInDish = (List<string>) entity.IngredientsInDish,
                    };
            }
        }
        public bool UpdateDish(DishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == model.DishID /*&& e.UserID == _userId*/);

                entity.Name = model.Name;
                //entity.IngredientsInDish = model.IngredientsInDish;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDish(int dishId)
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
