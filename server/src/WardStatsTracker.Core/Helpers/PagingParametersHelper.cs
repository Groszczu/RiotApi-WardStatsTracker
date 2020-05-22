using WardStatsTracker.Core.Interfaces;

namespace WardStatsTracker.Core.Helpers
{
    public static class PagingParametersHelper
    {
        public static (int startIndex, int endIndex) ConvertPageParametersToIndices(IPagingParameters pagingParameters)
        {
            var startIndex = (pagingParameters.Page - 1) * pagingParameters.PageSize;
            var endIndex = startIndex + pagingParameters.PageSize;

            return (startIndex, endIndex);
        }
    }
}