namespace DotNetCorePayroll.Data
{
    public partial class CompanyPayrollSetting
    {
        public int Id { get; set; }
        public long CompanyId { get; set; }
        public int? MonthPeriods { get; set; }
        public int? HoursPerDay { get; set; }
        public int? WeeklyPeriods { get; set; }
        public int? HourPerWeek { get; set; }
        public double? DaysPerMonth { get; set; }
        public string PayrollMessage { get; set; }

        public virtual Company Company { get; set; }
    }
}
