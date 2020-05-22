using System.ComponentModel.DataAnnotations;
using WardStatsTracker.Core.Interfaces;

namespace WardStatsTracker.Core.Parameters
{
    public class MatchesPagingParameters : IPagingParameters
    {
        public const int MaxPageSize = 100;
        public int Page { get; set; } = 1;
        
        [Range(1, MaxPageSize,
            ErrorMessage = "{0} must be between {1} and {2}")]
        public int PageSize { get; set; } = 15;
    }
}