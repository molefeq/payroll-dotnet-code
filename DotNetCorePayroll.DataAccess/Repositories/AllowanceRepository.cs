using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class AllowanceRepository : GenericRepository<Allowance>
    {
        private static string TRAVEL_ALLOWANCE = "TRAVEL_ALLOWANCE";
        private static string OTHER_ALLOWANCE = "OTHER_ALLOWANCE";

        public AllowanceRepository() : base() { }
        public AllowanceRepository(PayrollContext context) : base(context) { }

        public Allowance GetTravelAllowance(string year)
        {
            return GetById(item => TRAVEL_ALLOWANCE.Equals(item.Type) && year.Equals(item.Year));
        }

        public Allowance GetOtherAllowance(string year)
        {
            return GetById(item => OTHER_ALLOWANCE.Equals(item.Type) && year.Equals(item.Year));
        }
    }
}
