
namespace SuggestionAppLibrary.DataAccess;

public interface IUserData
{
   Task CreateUserAsync(UserModel user);
   Task<UserModel> GetUserAsync(string id);
   Task<UserModel> GetUserFromAuthenticationAsync(string objectId);
   Task<IEnumerable<UserModel>> GetUsersAsync();
   Task UpdateUserAsync(UserModel user);
}