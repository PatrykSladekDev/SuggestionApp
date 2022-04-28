
namespace SuggestionAppLibrary.DataAccess;

public interface ICategoryData
{
   Task CreateCategoryAsync(CategoryModel category);
   Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
}