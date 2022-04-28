
namespace SuggestionAppLibrary.DataAccess;

public interface IUserData
{
   Task CreateUser(UserModel user);
   Task<UserModel> GetUserAsync(string id);
   Task<UserModel> GetUserFromAuthentication(string objectId);
   Task<IEnumerable<UserModel>> GetUsersAsync();
   Task UpdateUser(UserModel user);
}