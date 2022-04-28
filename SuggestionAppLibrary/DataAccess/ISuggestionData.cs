
namespace SuggestionAppLibrary.DataAccess;

public interface ISuggestionData
{
   Task CreateStatusAsync(SuggestionModel suggestion);
   Task<IEnumerable<SuggestionModel>> GetAllApprovedSuggestionsAsync();
   Task<IEnumerable<SuggestionModel>> GetAllSuggestionsAsync();
   Task<IEnumerable<SuggestionModel>> GetAllSuggestionsWaitingForApprovalAsync();
   Task<SuggestionModel> GetSuggestionAsync(string id);
   Task UpdateSuggestion(SuggestionModel suggestion);
   Task UpvoteSuggestion(string suggestionId, string userId);
}