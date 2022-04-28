using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoStatusData : IStatusData
{
   private readonly IMongoCollection<StatusModel> _statuses;
   private readonly IMemoryCache _cache;
   private const string CacheName = "StatusData";

   public MongoStatusData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _statuses = db.StatusCollection;
   }

   public async Task<IEnumerable<StatusModel>> GetAllStatusesAsync()
   {
      var output = _cache.Get<IEnumerable<StatusModel>>(CacheName);
      if (output is null)
      {
         var results = await _statuses.FindAsync(_ => true);
         output = await results.ToListAsync();

         _cache.Set(CacheName, output, TimeSpan.FromDays(1));
      }

      return output;
   }

   public async Task CreateStatusAsync(StatusModel category)
   {
      await _statuses.InsertOneAsync(category);
   }
}
