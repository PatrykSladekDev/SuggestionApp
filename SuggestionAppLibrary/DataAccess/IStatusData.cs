
namespace SuggestionAppLibrary.DataAccess;

public interface IStatusData
{
   Task CreateStatus(StatusModel category);
   Task<IEnumerable<StatusModel>> GetAllStatusesAsync();
}