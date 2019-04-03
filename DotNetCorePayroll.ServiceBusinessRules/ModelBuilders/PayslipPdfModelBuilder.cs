using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Data;
using DotNetCorePayroll.PdfWriter.Constants;
using DotNetCorePayroll.PdfWriter.Models;
using Payslip.Common;
using System;
using System.Collections.Generic;

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
            payslipModel.Employee.Position = employee.EmployeePayrollEmployee.JobTitle;
            payslipModel.Employee.IdOrPassportNumber = employee.IdOrPassportNumber;
            payslipModel.Employee.DateOfEngagement = employee.EmployeePayrollEmployee.DateOfEngagement.ToShortDateString();
            payslipModel.Employee.TaxReferenceNumber = employee.TaxReferenceNumber;
        }

        public void BuildIncomeDetails(Employee employee)
        {
            payslipModel.IncomeDetails = new List<IncomeDetailModel>();

            payslipModel.IncomeDetails.Add(new IncomeDetailModel() { Description = IncomeDescription.BASIC_SALARY, Amount = employee.EmployeePayrollEmployee.BasicSalary });
            payslipModel.IncomeDetails.Add(new IncomeDetailModel() { Description = IncomeDescription.MEDICAL_AID_ALLOWANCE, Amount = employee.EmployeeMedicalAid.EmployerContribution });

            foreach (var allowance in employee.EmployeeAllowance)
            {
                payslipModel.IncomeDetails.Add(new IncomeDetailModel() { Description = allowance.AllowanceType.Name, Amount = allowance.Amount });
            }

            foreach (var benefit in employee.EmployeeBenefit)
            {
                payslipModel.IncomeDetails.Add(new IncomeDetailModel() { Description = benefit.Benefit.Name, Amount = benefit.EmployerContribution });
            }
        }

        public void BuildDeductionDetails(PayslipModel payslipInformation, Employee employee)
        {
            payslipModel.DeductionDetails = new List<DeductionDetailModel>();

            payslipModel.DeductionDetails.Add(new DeductionDetailModel() { Description = "Uif", Amount = payslipInformation.UifAmount });
            payslipModel.DeductionDetails.Add(new DeductionDetailModel() { Description = "PAYE", Amount = payslipInformation.TaxAmount });
        }

        public void BuildContibutions(PayslipModel payslipInformation, Employee employee)
        {
            payslipModel.DeductionDetails = new List<DeductionDetailModel>();

            foreach (var benefit in employee.EmployeeBenefit)
            {
                payslipModel.DeductionDetails.Add(new DeductionDetailModel() { Description = benefit.Benefit.Name, Amount = benefit.EmployerContribution });
            }
        }

        public void BuildBenefits(PayslipModel payslipInformation, Employee employee)
        {
        }

        public PayslipPdfModel GetPayslipPdfModel()
        {
            return payslipModel;
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
