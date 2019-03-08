using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class Benefit
    {
        public Benefit()
        {
            EmployeeBenefit = new HashSet<EmployeeBenefit>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<EmployeeBenefit> EmployeeBenefit { get; set; }
    }
}
