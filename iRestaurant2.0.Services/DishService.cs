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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public bool CreateDish(DishCreate model)
        {
                bool allWentWell = false;
            var entity =
                new Dish()
                {
                    Name = model.Name,
                   // IngredientsInDish = model.IngredientsInDish,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dishes.Add(entity);
                // return ctx.SaveChanges() == 1;
                var success = ctx.SaveChanges() == 1;

                foreach(var ingredientInDish in model.IngredientsInDish)
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
                        .Select( //Select is essentially a For Each Loop
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

                List<IngredientListItem> ingredientListItems = new List<IngredientListItem>();
                foreach(var ingredient in entity.IngredientsInDish)
                {
                    var potato = new IngredientListItem ()
                    {
                        IngredientID = ingredient.IngredientID,
                        Name = ingredient.Ingredient.Name,
                        Type = ingredient.Ingredient.Type
                    };
                    ingredientListItems.Add(potato);
                }
                   var dish = new DishDetail
                    {
                        DishID = entity.DishID,
                        Name = entity.Name,
                        IngredientsInDish = ingredientListItems
                    };
                return dish;
            }
        }
        public bool UpdateDish(DishEdit model) //model has ID, the new name, and a List of the new/old ingredients.
        {
            //bool allWentWell = false;
            //We need to create a new IngredientInDish that shows a change in relationship

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dishes
                        .Single(e => e.DishID == model.DishID);



                // query in IndgredientsInDIsh table for entities with model.DishID
                // delete those entities
                var iidEntity =
                    ctx
                        .IngredientsInDish
                        .Select(e => e.DishID == model.DishID);
                //foreach (DataRow row in iidEntity.Rows)
                foreach (var oldIngredients in ctx.IngredientsInDish)
                {
                    var happy = ctx.IngredientsInDish.Remove(oldIngredients);
                }
                ctx.SaveChanges();
                // try and get a count == 0 for validation
                var succeed = ctx.IngredientsInDish.Count() == 0;

               // entity.DishID = model.DishID;
                entity.Name = model.Name;

                // create new IndgredientInDish entities for each ingredient in the model's list of ingredients

                foreach (var newIngredients in model.IngredientsInDish)
                {
                    var ingredient =
                        new IngredientInDishCreate()
                        {
                            DishID = entity.DishID,
                            IngredientID = newIngredients
                        };
                    var succeeded = CreateIngredientInDish(ingredient);
                    //break the code or decide what you'll do if succeeded == false;
                    // if succeeded is false, return allWentWell
                }
               // allWentWell = true;
             ctx.SaveChanges();
            }
            //return allWentWell;
            return true; //plug in whatever validation you see fit to determine whether this method was successful
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
