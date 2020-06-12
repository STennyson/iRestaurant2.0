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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    Name = model.Name,
                    Type = model.Type,
                };
            _context.Ingredients.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<IngredientListItem> GetIngredients()
        {
            var ingredientEntities = _context.Ingredients.ToList();
            var ingredientList = ingredientEntities.Select(c => new IngredientListItem
            {
                IngredientID = c.IngredientID,
                Name = c.Name,
                Type = c.Type
            }).ToList();

            return ingredientList;
        }

        public IngredientDetail GetIngredientByID(int id)
        {
            var ingredientEntity = _context.Ingredients.Find(id);
            if (ingredientEntity == null)
                return null;

            var detail = new IngredientDetail
            {
                IngredientID = ingredientEntity.IngredientID,
                Name = ingredientEntity.Name,
                Type = ingredientEntity.Type
            };
            return detail;
        }

        public bool UpdateIngredient(IngredientEdit model)
        {
            var ingredientEntity = _context.Ingredients.Find(model.IngredientID);
            if (ingredientEntity == null)
                return false;

            ingredientEntity.IngredientID = model.IngredientID;
            ingredientEntity.Name = model.Name;
            ingredientEntity.Type = model.Type;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteIngredient(int IngredientID)
        {
            var entity = _context.Ingredients.Find(IngredientID);
            if (entity == null)
                return false;

            _context.Ingredients.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}

