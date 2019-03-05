using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels.Employee;
using Microsoft.Extensions.Configuration;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System.Collections.Generic;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IEmployeeService
    {
        EmployeeModel Find(long id);

        Result<EmployeeModel> GetEmployees(EmployeeSearchFilter employeeSearchFilter);

        EmployeeModel Add(EmployeeModel employeeModel);

        EmployeeModel Update(EmployeeModel employeeModel);

        EmployeeModel SaveAddressDetails(EmployeeAddressModel employeeAddressModel);

        EmployeeModel SaveCompanyDetails(EmployeeCompanyDetailModel employeeCompanyDetailModel);

        void Delete(long id);

        void ResizeLogos(EmployeeModel employeeModel, IConfiguration configuration, string rootPath, string currentUrl);

        void MapRelativeLogoPaths(List<EmployeeModel> employeeModels, IConfiguration configuration, string currentUrl);

        void MapRelativeLogoPath(EmployeeModel employeeModel, IConfiguration configuration, string currentUrl);
    }
}
