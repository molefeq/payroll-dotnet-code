using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class CalculatorModelBuilder
    {
        private static string TRAVEL_ALLOWANCE = "TRAVEL_ALLOWANCE";
        private static string OTHER_ALLOWANCE = "OTHER_ALLOWANCE";
        private static string RETIREMENT_ANNUITY = "RETIREMENT_ANNUITY";

        //private CalculatorModel calculatorModel = new CalculatorModel();

        public CalculatorModelBuilder() { }

        public void buildCalculatorModel(Employee employee, IUnitOfWork unitOfWork)
        {
            var year = DateTime.Now.GetTaxYear();
            var employeeAge = employee.DateOfBirth.GetAge();

            var travelAllowance = unitOfWork.Allowance.GetTravelAllowance(year);
            var otherAllowance = unitOfWork.Allowance.GetOtherAllowance(year);
            var mainMemberMedicalAidCredit = unitOfWork.MedicalAidTaxCredit.GetMainMemberMedicalCredit(year);
            var firstDependantMedicalAidCredit = unitOfWork.MedicalAidTaxCredit.GetFirstDependantMedicalCredit(year);
            var otherDependantMedicalAidCredit = unitOfWork.MedicalAidTaxCredit.GetOtherDependantMedicalCredit(year);
            var uif = unitOfWork.Uif.GetUif(DateTime.Now);
            var pensionFund = unitOfWork.PensionFund.GetPensionFund(year);
            var incomeTaxTable = unitOfWork.IncomeTax.GetEntities(item => year.Equals(item.Year)).ToList();
            var payrollInformation = employee.EmployeePayrollEmployee;
            var allowances = employee.EmployeeAllowance.ToList();
            var benefits = employee.EmployeeBenefit.ToList();
            var medicalAid = employee.EmployeeMedicalAid;
            var taxRebate = unitOfWork.TaxRebate.GetTaxRebate(employeeAge, year);
            var taxThreshold = unitOfWork.TaxThreshold.GetTaxThreshold(employeeAge, year);

            if (payrollInformation == null)
            {
                return;
            }

            //BuildTravelAllowance(allowances);
            //BuildOtherAllowance(allowances);
            //BuildEmployerRetirementAnnuityAContribution(benefits);
            //BuildEmployeeRetirementAnnuityAContribution(benefits);
            //BuildEmployerMedicalAidContribution(medicalAid);
            //BuildMedicalAidNumberOfDependants(medicalAid);
            // calculatorModel.BasicSalary = payrollInformation.BasicSalary;
            // calculatorModel.TravelAllowanceInclusionPercentage = travelAllowance.TaxPercentage;
            // calculatorModel.PaymentRefrequency = payrollInformation.PaymentFrequency.Frequency;
            // calculatorModel.LimitPercentageForRetirementFundsContributions = pensionFund.AnnualRemunerationPercent;
            // calculatorModel.MaximumRetirementFundsContributions = pensionFund.MaximumAmount;
            // calculatorModel.MainMemberMedicalAidCredit = mainMemberMedicalAidCredit.CreditAmount;
            // calculatorModel.FirstDependentMedicalAidCredit = firstDependantMedicalAidCredit.CreditAmount; ;
            // calculatorModel.OtherDependentMedicalAidCredit = otherDependantMedicalAidCredit.CreditAmount; ;
            // calculatorModel.SlidingScale = 0;
            // calculatorModel.TaxPercentage = 0;
            // calculatorModel.MinimumNonTaxableAmount = 0;
            // calculatorModel.TaxRebate = taxRebate.RebateAmount;
            // calculatorModel.UifLimit = uif.MaximumAmount;
        }

        // public void BuildTravelAllowance(List<EmployeeAllowance> allowances)
        // {
        //     if (allowances.Count == 0)
        //     {
        //         calculatorModel.TravelAllowance = 0;
        //         return;
        //     }

        //     calculatorModel.TravelAllowance = allowances.Where(a => TRAVEL_ALLOWANCE.Equals(a.AllowanceType.Type)).Sum(item => item.Amount);
        // }

        // public void BuildOtherAllowance(List<EmployeeAllowance> allowances)
        // {
        //     if (allowances.Count == 0)
        //     {
        //         calculatorModel.TravelAllowance = 0;
        //         return;
        //     }

        //     calculatorModel.TravelAllowance = allowances.Where(a => OTHER_ALLOWANCE.Equals(a.AllowanceType.Type)).Sum(item => item.Amount);
        // }

        // public void BuildEmployerRetirementAnnuityAContribution(List<EmployeeBenefit> benefits)
        // {
        //     if (benefits.Count == 0)
        //     {
        //         calculatorModel.EmployerContribution = 0;
        //         return;
        //     }

        //     calculatorModel.EmployerContribution = benefits.Where(a => RETIREMENT_ANNUITY.Equals(a.Benefit.Type)).Sum(item => item.EmployerContribution);
        // }

        // public void BuildEmployeeRetirementAnnuityAContribution(List<EmployeeBenefit> benefits)
        // {
        //     if (benefits.Count == 0)
        //     {
        //         calculatorModel.EmployeeContribution = 0;
        //         return;
        //     }

        //     calculatorModel.EmployeeContribution = benefits.Where(a => RETIREMENT_ANNUITY.Equals(a.Benefit.Type)).Sum(item => item.EmployeeContribution);
        // }

        // public void BuildEmployerMedicalAidContribution(EmployeeMedicalAid medicalAid)
        // {
        //     if (medicalAid == null)
        //     {
        //         calculatorModel.EmployerMedicalAidContribution = 0;
        //         return;
        //     }

        //     calculatorModel.EmployeeContribution = medicalAid.EmployerContribution;
        // }

        // public void BuildMedicalAidNumberOfDependants(EmployeeMedicalAid medicalAid)
        // {
        //     if (medicalAid == null)
        //     {
        //         calculatorModel.NumberOfDependants = 0;
        //         return;
        //     }

        //     calculatorModel.NumberOfDependants = medicalAid.NumberOfDependants + 1;
        // }

    }
}
