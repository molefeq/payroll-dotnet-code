using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Company
{
    public class CompanyPayrollSettingModel
    {
        public long? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public int? MonthPeriods { get; set; }
        public int? HoursPerDay { get; set; }
        public int? WeeklyPeriods { get; set; }
        public int? HoursPerWeek { get; set; }
        public double? DaysPerMonth { get; set; }
        public string PayslipMessage { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
