using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels.Employee;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using Microsoft.Extensions.Configuration;
using Payslip.Calculator;
using Payslip.Sars.Builders;
using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork unitOfWork;
        private EmployeeBuilder employeeBuilder;
        private EmployeeAdapter employeeAdapter;
        private ICalculateService calculateService;

        public EmployeeService(IUnitOfWork unitOfWork, EmployeeBuilder employeeBuilder, EmployeeAdapter employeeAdapter,
            ICalculateService calculateService)
        {
            this.unitOfWork = unitOfWork;
            this.employeeBuilder = employeeBuilder;
            this.employeeAdapter = employeeAdapter;
            this.calculateService = calculateService;
        }

        public EmployeeModel Add(EmployeeModel employeeModel)
        {
            var employee = employeeBuilder.Build(employeeModel);

            unitOfWork.Employee.Insert(employee);
            unitOfWork.Save();

            return employeeBuilder.BuildToEmployeeModel(unitOfWork.Employee.GetById(o => o.Id == employee.Id));
        }

        public void Delete(long id)
        {
            var employee = unitOfWork.Employee.GetById(o => o.Id == id);

            if (employee == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Employee you trying to delete does not exist."));
            }

            unitOfWork.Employee.Delete(employee);
            unitOfWork.Save();
        }

        public EmployeeModel Find(long id)
        {
            var employee = unitOfWork.Employee.GetById(o => o.Id == id, "PhysicalAddress, PostalAddress");

            if (employee == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Employee you trying to update does not exist."));
            }

            return employeeBuilder.BuildToEmployeeModel(employee);
        }

        public Result<EmployeeModel> GetEmployees(EmployeeSearchFilter employeeSearchFilter)
        {
            var results = unitOfWork.Employee.Get(employeeSearchFilter);

            return new Result<EmployeeModel>
            {
                Items = results.Items.Select(o => employeeBuilder.BuildToEmployeeModel(o)).ToList(),
                TotalItems = results.TotalItems
            };
        }

        public EmployeeModel SaveAddressDetails(EmployeeAddressModel employeeAddressModel)
        {
            var employee = unitOfWork.Employee.GetById(o => o.Id == employeeAddressModel.EmployeeId, "PhysicalAddress, PostalAddress");

            if (employee == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Employee you trying to update does not exist."));
            }

            employeeAdapter.UpdateAddressDetails(employee, employeeAddressModel);
            unitOfWork.Employee.Update(employee);
            unitOfWork.Save();

            return employeeBuilder.BuildToEmployeeModel(unitOfWork.Employee.GetById(o => o.Id == employeeAddressModel.EmployeeId));
        }

        public EmployeeModel SaveCompanyDetails(EmployeeCompanyDetailModel employeeCompanyDetailModel)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            var employee = unitOfWork.Employee.GetById(o => o.Id == employeeModel.Id.Value);

            if (employee == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Employee you trying to update does not exist."));
            }

            employeeAdapter.Update(employee, employeeModel);
            unitOfWork.Employee.Update(employee);
            unitOfWork.Save();

            return employeeBuilder.BuildToEmployeeModel(unitOfWork.Employee.GetById(o => o.Id == employee.Id));
        }

        public void CreatePaySlip(long employeeId)
        {
            var employee = unitOfWork.Employee.GetById(o => o.Id == employeeId);

            var builder = new CalculatorModelBuilder();
            var sarsPayslipBuilder = new SarsPayslipBuilder(calculateService);
            var sarsTaxIncomeBuilder = new SarsTaxIncomeBuilder();

            builder.buildCalculatorModel(employee: employee, unitOfWork: unitOfWork);
            sarsTaxIncomeBuilder.buildSarsTaxIncomeTable(unitOfWork: unitOfWork);

            var calculatorModel = builder.GetModel();
            var sarsTaxIncomeTable = sarsTaxIncomeBuilder.GetSarsTaxIncomeTable();

            sarsPayslipBuilder.buildPayslip(calculatorModel, sarsTaxIncomeTable);

            var payslipCalculation = sarsPayslipBuilder.getPayslip();
        }

        public void MapRelativeLogoPath(EmployeeModel employeeModel, IConfiguration configuration, string currentUrl)
        {
            if (string.IsNullOrEmpty(employeeModel.ImageFileName))
            {
                return;
            }

            employeeModel.ImageFileNamePath = FileHandler.GetRelativeFileName(new Uri(currentUrl + configuration.EmployeePreviewDirectory()).AbsoluteUri, employeeModel.ImageFileName);
        }

        public void MapRelativeLogoPaths(List<EmployeeModel> employeeModels, IConfiguration configuration, string currentUrl)
        {
            if (employeeModels == null || employeeModels.Count == 0)
            {
                return;
            }

            employeeModels.ForEach(item => MapRelativeLogoPath(item, configuration, currentUrl));
        }

        public void ResizeLogos(EmployeeModel employeeModel, IConfiguration configuration, string rootPath, string currentUrl)
        {
            string tempPhysicalTempDirectory = rootPath + configuration.EmployeeNormalTempDirectory();
            string logoFileName = FileHandler.GetPhysicalFileName(tempPhysicalTempDirectory, employeeModel.ImageFileName);

            FileHandler.ResizeImage(logoFileName, employeeModel.ImageFileName,
                new ImageModel
                {

                    Width = configuration.EmployeeNormalImageWidth(),
                    Height = configuration.EmployeeNormalImageHeight(),
                    PhysicalDirectory = rootPath + configuration.EmployeeNormalDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.EmployeeNormalDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, employeeModel.ImageFileName,
                new ImageModel
                {
                    Width = configuration.EmployeeThumbnailImageWidth(),
                    Height = configuration.EmployeeThumbnailImageHeight(),
                    PhysicalDirectory = rootPath + configuration.EmployeeThumbnailDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.EmployeeThumbnailDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, employeeModel.ImageFileName,
                new ImageModel
                {
                    Width = configuration.EmployeePreviewImageWidth(),
                    Height = configuration.EmployeePreviewImageHeight(),
                    PhysicalDirectory = rootPath + configuration.EmployeePreviewDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.EmployeePreviewDirectory()).AbsoluteUri
                });
        }
    }
}
