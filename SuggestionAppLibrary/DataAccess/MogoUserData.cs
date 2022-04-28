namespace SuggestionAppLibrary.DataAccess;

public class MogoUserData : IUserData
{
   private readonly IMongoCollection<UserModel> _users;

   public MogoUserData(IDbConnection db)
   {
      _users = db.UserCollection;
   }

   public async Task<IEnumerable<UserModel>> GetUsersAsync()
   {
      var result = await _users.FindAsync(_ => true);
      return await result.ToListAsync();
   }

   public async Task<UserModel> GetUserAsync(string id)
   {
      var result = await _users.FindAsync(u => u.Id == id);
      return await result.FirstOrDefaultAsync();
   }

   public async Task<UserModel> GetUserFromAuthentication(string objectId)
   {
      var result = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
      return await result.FirstOrDefaultAsync();
   }

   public async Task CreateUser(UserModel user)
   {
      await _users.InsertOneAsync(user);
   }

   public async Task UpdateUser(UserModel user)
   {
      var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
      await _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
   }
}
