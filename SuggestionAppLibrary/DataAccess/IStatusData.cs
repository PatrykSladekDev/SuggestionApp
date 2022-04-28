
namespace SuggestionAppLibrary.DataAccess;

public interface IStatusData
{
   Task CreateStatusAsync(StatusModel category);
   Task<IEnumerable<StatusModel>> GetAllStatusesAsync();
}