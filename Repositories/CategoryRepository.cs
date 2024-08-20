using CarSaleProject.Data;
using CarSaleProject.Models;
using CarSaleProject.Repositories;


namespace CategorySaleProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<CategoryDTO> _categories = new List<CategoryDTO>();

        private readonly DataContext _context;

        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }

        public void AddCategory(CategoryDTO _category)
        {
            Category category = new Category();

            category.Name = _category.Name; 
            
            category.FilePath = _category.FilePath;

            _context.Categories.Add(category);
            _context.SaveChanges();
           // _categories.Add(category);
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categories;
        }

        public CategoryDTO GetCategoryByListingNumber(int listingNumber)
        {
            foreach (var category in _categories) { 
               
                if(category.ListingNumber == listingNumber)
                {
                    return category;
                }
            }
            return null;
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var existingCategory = GetCategoryByListingNumber(category.ListingNumber);
            if (existingCategory != null)
            {
                existingCategory.FilePath = category.FilePath;
                existingCategory.Name = category.Name;
               
            }
        }

        public void DeleteCategory(CategoryDTO category)
        {
            _categories.Remove(category);           
        }

    }
}

