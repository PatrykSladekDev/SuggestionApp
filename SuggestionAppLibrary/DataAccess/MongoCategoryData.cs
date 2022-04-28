﻿using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess;

public class MongoCategoryData : ICategoryData
{
   private readonly IMongoCollection<CategoryModel> _categories;
   private readonly IMemoryCache _cache;
   private const string CacheName = "CategoryData";

   public MongoCategoryData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _categories = db.CategoryCollection;
   }

   public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
   {
      var output = _cache.Get<IEnumerable<CategoryModel>>(CacheName);
      if (output is null)
      {
         var results = await _categories.FindAsync(_ => true);
         output = await results.ToListAsync();

         _cache.Set(CacheName, output, TimeSpan.FromDays(1));
      }

      return output;
   }

   public async Task CreateCategoryAsync(CategoryModel category)
   {
      await _categories.InsertOneAsync(category);
   }
}
