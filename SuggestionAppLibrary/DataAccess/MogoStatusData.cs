using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MogoStatusData : IStatusData
{
   private readonly IMongoCollection<StatusModel> _statuses;
   private readonly IMemoryCache _cache;
   private readonly string cacheName = "StatusData";

   public MogoStatusData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _statuses = db.StatusCollection;
   }

   public async Task<IEnumerable<StatusModel>> GetAllStatusesAsync()
   {
      var output = _cache.Get<IEnumerable<StatusModel>>(cacheName);
      if (output is null)
      {
         var results = await _statuses.FindAsync(_ => true);
         output = await results.ToListAsync();

         _cache.Set(cacheName, output, TimeSpan.FromDays(1));
      }

      return output;
   }

   public async Task CreateStatus(StatusModel category)
   {
      await _statuses.InsertOneAsync(category);
   }
}
