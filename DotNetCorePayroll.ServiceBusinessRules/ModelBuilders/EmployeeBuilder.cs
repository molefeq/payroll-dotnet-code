using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels.Employee;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class EmployeeBuilder
    {
        private AddressBuilder addressBuilder;

        public EmployeeBuilder(AddressBuilder addressBuilder)
        {
            this.addressBuilder = addressBuilder;
        }

        public Employee Build(EmployeeModel employeeModel)
        {
            Employee employee = new Employee
            {
                Title = employeeModel.Title,
                FirstName = employeeModel.FirstName,
                Initials = employeeModel.Initials,
                LastName = employeeModel.LastName,
                NickName = employeeModel.NickName,
                DateOfBirth = employeeModel.DateOfBirth,
                Gender = employeeModel.Gender,
                DisabilityDescription = employeeModel.DisabilityDescription,
                MaritalStatus = employeeModel.MaritalStatus,
                HomeLanguage = employeeModel.HomeLanguage,
                TaxReferenceNumber = employeeModel.TaxReferenceNumber,
                StatusId = employeeModel.StatusId,
                EthnicGroup = employeeModel.EthnicGroup,
                EmployeeNumber = employeeModel.EmployeeNumber,
                IdOrPassportNumber = employeeModel.IdOrPassportNumber,
                EmailAddress = employeeModel.EmailAddress,
                WorkNumber = employeeModel.WorkNumber,
                HomeNumber = employeeModel.HomeNumber,
                MobileNumber = employeeModel.MobileNumber,
                ImageFileName = employeeModel.ImageFileName,
                CreateDate = DateTime.Now,
                CreateUserId = employeeModel.UserId
            };

            return employee;
        }

        public EmployeeModel BuildToEmployeeModel(Employee employee)
        {
            EmployeeModel employeeModel = new EmployeeModel
            {
                Title = employee.Title,
                FirstName = employee.FirstName,
                Initials = employee.Initials,
                LastName = employee.LastName,
                NickName = employee.NickName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                DisabilityDescription = employee.DisabilityDescription,
                MaritalStatus = employee.MaritalStatus,
                HomeLanguage = employee.HomeLanguage,
                TaxReferenceNumber = employee.TaxReferenceNumber,
                StatusId = employee.StatusId,
                EthnicGroup = employee.EthnicGroup,
                EmployeeNumber = employee.EmployeeNumber,
                IdOrPassportNumber = employee.IdOrPassportNumber,
                EmailAddress = employee.EmailAddress,
                WorkNumber = employee.WorkNumber,
                HomeNumber = employee.HomeNumber,
                MobileNumber = employee.MobileNumber,
                ImageFileName = employee.ImageFileName
            };

            employeeModel.Address = new EmployeeAddressModel
            {
                EmployeeId = employee.Id,
                PhysicalAddress = addressBuilder.BuildToModel(employee.PhysicalAddress),
                PostalAddress = addressBuilder.BuildToModel(employee.PostalAddress)
            };

            return employeeModel;
        }
    }
}

