using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels.Employee;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class EmployeeAdapter
    {
        private AddressBuilder addressBuilder;
        private AddressAdapter addressAdapter;

        public EmployeeAdapter(AddressBuilder addressBuilder, AddressAdapter addressAdapter)
        {
            this.addressBuilder = addressBuilder;
            this.addressAdapter = addressAdapter;
        }

        public void Update(Employee employee, EmployeeModel employeeModel)
        {
            employee.Title = employeeModel.Title;
            employee.FirstName = employeeModel.FirstName;
            employee.Initials = employeeModel.Initials;
            employee.LastName = employeeModel.LastName;
            employee.NickName = employeeModel.NickName;
            employee.DateOfBirth = employeeModel.DateOfBirth.Value;
            employee.Gender = employeeModel.Gender;
            employee.DisabilityDescription = employeeModel.DisabilityDescription;
            employee.MaritalStatus = employeeModel.MaritalStatus;
            employee.HomeLanguage = employeeModel.HomeLanguage;
            employee.TaxReferenceNumber = employeeModel.TaxReferenceNumber;
            employee.StatusId = employeeModel.StatusId.Value;
            employee.EthnicGroup = employeeModel.EthnicGroup;
            employee.EmployeeNumber = employeeModel.EmployeeNumber;
            employee.IdOrPassportNumber = employeeModel.IdOrPassportNumber;
            employee.EmailAddress = employeeModel.EmailAddress;
            employee.WorkNumber = employeeModel.WorkNumber;
            employee.HomeNumber = employeeModel.HomeNumber;
            employee.MobileNumber = employeeModel.MobileNumber;
            employee.ImageFileName = employeeModel.ImageFileName;
            employee.ModifiedDate = DateTime.Now;
            employee.ModifiedUserId = employeeModel.UserId;
        }

        public void UpdateAddressDetails(Employee employee, EmployeeAddressModel addressModel)
        {
            if (employee.PostalAddressId == null)
            {
                employee.PostalAddress = addressBuilder.Build(addressModel.PostalAddress);
            }
            else
            {
                addressAdapter.Update(employee.PostalAddress, addressModel.PostalAddress);
            }

            if (employee.PhysicalAddress == null)
            {
                employee.PhysicalAddress = addressBuilder.Build(addressModel.PhysicalAddress);
            }
            else
            {
                addressAdapter.Update(employee.PhysicalAddress, addressModel.PhysicalAddress);
            }
        }
    }
}
