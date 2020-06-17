using iRestaurant2._0.Data;
using iRestaurant2._0.Models.DishModels;
using iRestaurant2._0.Models.IngredientInDishModels;
using iRestaurant2._0.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Services
{
    public class DishService
    {
        public bool CreateDish(DishCreate model)
        {
            try
            {
                bool allWentWell = false;
                var entity =
                    new Dish()
                    {
                        Name = model.Name,
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Dishes.Add(entity);
                    var success = ctx.SaveChanges() == 1;

                    foreach (var ingredientInDish in model.IngredientsInDish)
                    {
                        var ingredient =
                            new IngredientInDishCreate()
                            {
                                DishID = entity.DishID,
                                IngredientID = Convert.ToInt32(ingredientInDish)
                            };
                        var succeeded = CreateIngredientInDish(ingredient);
                        //break the code or decide what you'll do if succeeded == false;
                        // if succeeded is false, return allWentWell
                    }
                    allWentWell = true;
                }
                return allWentWell;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateIngredientInDish(IngredientInDishCreate ingredientModel)
        {
            var entity =
                new IngredientInDish()
                {
                    DishID = ingredientModel.DishID,
                    IngredientID = ingredientModel.IngredientID,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IngredientsInDish.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateIngredientInDish(IngredientInDishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .IngredientsInDish
                        .Single(e => e.DishID == model.DishID);

                entity.IngredientInDishID = model.IngredientInDishID;
                entity.DishID = model.DishID;
                entity.IngredientID = model.IngredientID;

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
        public DishDetail GetDishById(int id)
        {


            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == id);

                List<IngredientListItem> ingredientListItems = new List<IngredientListItem>();
                foreach (var ingredient in entity.IngredientsInDish)
                {
                    var potato = new IngredientListItem()
                    {
                        IngredientID = ingredient.IngredientID,
                        Name = ingredient.Ingredient.Name,
                        Type = ingredient.Ingredient.Type,
                        Price = ingredient.Ingredient.Price
                    };
                    ingredientListItems.Add(potato);
                }
                var total = PriceCalc(entity.DishID);

                var dish = new DishDetail
                {
                    DishID = entity.DishID,
                    Name = entity.Name,
                    IngredientsInDish = ingredientListItems,
                    TotalPrice = total
                };
                return dish;
            }
        }
        public bool UpdateDish(DishEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity =
                      ctx
                          .Dishes
                          .Single(e => e.DishID == model.DishID);
                    if (entity == null)
                        return false;


                    var iidEntity =
                        ctx
                            .IngredientsInDish
                            .Select(e => e.DishID == model.DishID);

                    foreach (var oldIngredients in ctx.IngredientsInDish)
                    {
                        var happy = ctx.IngredientsInDish.Remove(oldIngredients);
                    }
                    ctx.SaveChanges();
                    var succeed = ctx.IngredientsInDish.Count() == 0;

                    entity.Name = model.Name;

                    foreach (var newIngredients in model.IngredientsInDish)
                    {
                        var ingredient =
                            new IngredientInDishCreate()
                            {
                                DishID = entity.DishID,
                                IngredientID = newIngredients
                            };
                        var succeeded = CreateIngredientInDish(ingredient);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public bool DeleteDish(int dishId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == dishId);

                ctx.Dishes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public double PriceCalc(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == id);

                List<IngredientListItem> myList = new List<IngredientListItem>();

                foreach (var ingredient in entity.IngredientsInDish)
                {

                    var dollar = new IngredientListItem()
                    {
                        IngredientID = ingredient.IngredientID,
                        Name = ingredient.Ingredient.Name,
                        Type = ingredient.Ingredient.Type,
                        Price = ingredient.Ingredient.Price
                    };
                    myList.Add(dollar);

                }
                var priceList = myList.Select(x => x.Price).ToArray();
                return priceList.Sum();
            }




        }
    }
}
