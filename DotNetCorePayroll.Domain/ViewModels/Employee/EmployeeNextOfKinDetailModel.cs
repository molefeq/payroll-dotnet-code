using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Employee
{
    public class EmployeeNextOfKinDetailModel
    {
        public long? Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string ContactNumber { get; set; }
        public string Relationship { get; set; }

        public CrudStatus CrudStatus { get; set; }
    }
}
