using CategoryService.Models;
using CategoryService.Database;
namespace CategoryService.DAL
{
    public class DataAccess
    {
        CategoriesDB database = new CategoriesDB();
        public IEnumerable<Category> GetAllCategories()
        {
            return database;
        }
        public Category GetCategories(int id)
        {
            return database.First(c => c.CategoryId == id);
        }
        public IEnumerable<Category> CreateCategory(Category category)
        {
            database.Add(category);
            return database;
        }
        public IEnumerable<Category> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                //1. search category from database based in 'id'
                var cat = database.First(c => c.CategoryId == id);



                //2. Remove the search Cateory 
                database.Remove(cat);



                //3. Add the new updated category
                database.Add(category);
            }
            return database;
        }
        public IEnumerable<Category> DeleteCategory(int id)
        {
            //1. search category from database based in 'id'
            var cat = database.First(c => c.CategoryId == id);



            //2. Remove the search Cateory 
            database.Remove(cat);
            return database;
        }
    }
}
