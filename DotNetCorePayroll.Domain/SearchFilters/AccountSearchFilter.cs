namespace DotNetCorePayroll.Data.SearchFilters
{
    public class AccountSearchFilter: SearchFilter
    {
        public int? OrganisationId { get; set; }
        public int? CompanyId { get; set; }
    }
}
