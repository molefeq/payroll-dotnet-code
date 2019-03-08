using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class AllowanceType
    {
        public AllowanceType()
        {
            EmployeeAllowance = new HashSet<EmployeeAllowance>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<EmployeeAllowance> EmployeeAllowance { get; set; }
    }
}
