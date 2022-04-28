
namespace SuggestionAppLibrary.DataAccess;

public interface ICategoryData
{
   Task CreateCategory(CategoryModel category);
   Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();
}