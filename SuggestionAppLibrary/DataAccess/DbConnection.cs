using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess;

public class DbConnection
{
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";
   public string DbName { get; private set; }
   public string CategoryCollectionName { get; private set; } = "categories";
   public string StatusCollecionName { get; private set; } = "statuses";
   public string UserCollecionName { get; private set; } = "users";
   public string SuggestionCollecionName { get; private set; } = "suggestions";

   public MongoClient Clinet { get; private set; }
   public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
   public IMongoCollection<StatusModel> StatusCollection { get; private set; }
   public IMongoCollection<UserModel> UserCollection { get; private set; }
   public IMongoCollection<SuggestionModel> SuggestionCollection { get; private set; }

   public DbConnection(IConfiguration config)
   {
      _config = config;
      Clinet = new MongoClient(_config.GetConnectionString(_connectionId));
      DbName = _config["DatabaseName"];
      _db = Clinet.GetDatabase(DbName);

      CategoryCollection = _db.GetCollection<CategoryModel>(CategoryCollectionName);
      StatusCollection = _db.GetCollection<StatusModel>(StatusCollecionName);
      UserCollection = _db.GetCollection<UserModel>(UserCollecionName);
      SuggestionCollection = _db.GetCollection<SuggestionModel>(SuggestionCollecionName);
   }
}
