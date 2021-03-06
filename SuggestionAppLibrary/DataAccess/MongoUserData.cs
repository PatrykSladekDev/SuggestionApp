namespace SuggestionAppLibrary.DataAccess;

public class MongoUserData : IUserData
{
   private readonly IMongoCollection<UserModel> _users;

   public MongoUserData(IDbConnection db)
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

   public async Task<UserModel> GetUserFromAuthenticationAsync(string objectId)
   {
      var result = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
      return await result.FirstOrDefaultAsync();
   }

   public async Task CreateUserAsync(UserModel user)
   {
      await _users.InsertOneAsync(user);
   }

   public async Task UpdateUserAsync(UserModel user)
   {
      var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
      await _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
   }
}
