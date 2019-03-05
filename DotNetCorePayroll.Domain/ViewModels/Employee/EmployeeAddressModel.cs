namespace DotNetCorePayroll.Data.ViewModels.Employee
{
    public class EmployeeAddressModel
    {
        public long EmployeeId { get; set; }
        public AddressModel PhysicalAddress { get; set; }
        public AddressModel PostalAddress { get; set; }
    }
}
