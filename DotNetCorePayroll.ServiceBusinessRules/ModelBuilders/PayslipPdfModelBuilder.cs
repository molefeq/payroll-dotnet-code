using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Data;
using DotNetCorePayroll.PdfWriter.Models;
using Payslip.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class PayslipPdfModelBuilder
    {
        private PayslipPdfModel payslipModel = new PayslipPdfModel();

        public void Build(PayslipModel payslipInformation, Employee employee)
        {
            payslipModel.Date = DateTime.Now.DateToString();
            payslipModel.NetPayAmount = payslipInformation.TakeHomeAmount;
            payslipModel.Period = (DateTime.Now.Month - 2).ToString();
            payslipModel.TotalDeductions = payslipInformation.TaxAmount;
            payslipModel.TotalGrossEarnings = payslipInformation.CostToCompany;
        }

        public void BuildCompanyDetail(Company company)
        {
            payslipModel.Company = new PayslipCompanyModel();

            payslipModel.Company.EmailAddress = company.EmailAddress;
            payslipModel.Company.Name = company.Name;
            payslipModel.Company.RegistrationNumber = company.CompanyRegistrationNumber;
            payslipModel.Company.TelephoneNumber = company.ContactNumber;

            payslipModel.Company.Address = MapAddressToPdfAddress(company.PhysicalAddress);
        }

        public void BuildEmployeeDetail(Employee employee)
        {
            payslipModel.Employee = new PayslipEmployeeModel();

            payslipModel.Employee.EmailAddress = employee.EmailAddress;
            payslipModel.Employee.EmployeeNumber = employee.EmployeeNumber;
            payslipModel.Employee.Name = $"{employee.Title} {employee.FirstName} {employee.LastName}";
            payslipModel.Employee.Position = "";
            payslipModel.Employee.IdOrPassportNumber = employee.IdOrPassportNumber;
            payslipModel.Employee.DateOfEngagement = "";
            payslipModel.Employee.TaxReferenceNumber = "";
        }

        public void BuildIncomeDetails(Employee employee)
        {
            payslipModel.IncomeDetails = new List<IncomeDetailModel>();

            payslipModel.Employee.EmailAddress = employee.EmailAddress;
            payslipModel.Employee.EmployeeNumber = employee.EmployeeNumber;
            payslipModel.Employee.Name = $"{employee.Title} {employee.FirstName} {employee.LastName}";
            payslipModel.Employee.Position = "";
            payslipModel.Employee.IdOrPassportNumber = employee.IdOrPassportNumber;
            payslipModel.Employee.DateOfEngagement = "";
            payslipModel.Employee.TaxReferenceNumber = "";
        }

        private PdfPAddress MapAddressToPdfAddress(Address address)
        {
            PdfPAddress pdfPAddress = new PdfPAddress();

            pdfPAddress.AddressLine1 = address.Line1;
            pdfPAddress.AddressLine2 = address.Line2;
            pdfPAddress.Suburb = address.Suburb;
            pdfPAddress.City = address.City;
            pdfPAddress.Province = address.Province.Name;
            pdfPAddress.Country = address.Country.Name;
            pdfPAddress.PostalCode = address.PostalCode;

            return pdfPAddress;
        }
    }
}
