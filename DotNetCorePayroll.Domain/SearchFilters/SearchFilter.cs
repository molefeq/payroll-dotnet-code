using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.Data.SearchFilters
{
    public class SearchFilter
    {
        public string SearchText { get; set; }
        public PageData PageData { get; set; }
    }
}
