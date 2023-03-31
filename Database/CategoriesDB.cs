using CategoryService.Models;

namespace CategoryService.Database
{
    public class CategoriesDB : List<Category>
    {
        public CategoriesDB()
        {
            Add(new Category() { CategoryId = 1, CategoryName = "c1", BasePrice = 11000 });
            Add(new Category() { CategoryId = 2, CategoryName = "c2", BasePrice = 12000 });
            Add(new Category() { CategoryId = 3, CategoryName = "c3", BasePrice = 13000 });
            Add(new Category() { CategoryId = 4, CategoryName = "c4", BasePrice = 14000 });
        }
    }
}
