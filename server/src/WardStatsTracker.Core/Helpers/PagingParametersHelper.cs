using WardStatsTracker.Core.Interfaces;

namespace WardStatsTracker.Core.Helpers
{
    public static class PagingParametersHelper
    {
        public static (int beginIndex, int endIndex) ConvertPageParametersToIndices(IPagingParameters pagingParameters)
        {
            var beginIndex = (pagingParameters.Page - 1) * pagingParameters.PageSize;
            var endIndex = beginIndex + pagingParameters.PageSize;

            return (beginIndex, endIndex);
        }
    }
}