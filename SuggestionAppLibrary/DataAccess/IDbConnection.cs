namespace SuggestionAppLibrary.DataAccess;

public interface IDbConnection
{
   IMongoCollection<CategoryModel> CategoryCollection { get; }
   string CategoryCollectionName { get; }
   MongoClient Clinet { get; }
   string DbName { get; }
   string StatusCollecionName { get; }
   IMongoCollection<StatusModel> StatusCollection { get; }
   string SuggestionCollecionName { get; }
   IMongoCollection<SuggestionModel> SuggestionCollection { get; }
   string UserCollecionName { get; }
   IMongoCollection<UserModel> UserCollection { get; }
}