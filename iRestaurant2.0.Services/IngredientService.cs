using iRestaurant2._0.Data;
using iRestaurant2._0.Models.IngredientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRestaurant2._0.Services
{
    public class IngredientService
    {
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    Name = model.Name,
                    Type = model.Type
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ingredients
                        //.Where(e => e.IngredientID == IngredientID)
                        .Select(
                            e =>
                                new IngredientListItem
                                {
                                    IngredientID = e.IngredientID,
                                    Name = e.Name,
                                    Type = e.Type,
                                }
                        );

                return query.ToArray();
            }
        }
        public IngredientDetail GetIngredientByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == id);
                return
                    new IngredientDetail
                    {
                        IngredientID = entity.IngredientID,
                        Name = entity.Name,
                        Type = entity.Type,
                    };
            }
        }
        public bool UpdateIngredient(IngredientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == model.IngredientID);

                entity.IngredientID = model.IngredientID;
                entity.Name = model.Name;
                entity.Type = model.Type;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteIngredient(int IngredientID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ingredients
                        .Single(e => e.IngredientID == IngredientID);

                ctx.Ingredients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

