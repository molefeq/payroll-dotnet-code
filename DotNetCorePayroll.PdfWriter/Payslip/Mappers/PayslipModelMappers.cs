using Libraries.Common.Extensions;

using DotNetCorePayroll.PdfWriter.Models;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
{
    public class PayslipModelMappers
    {
        private static PayslipModelMappers _instance;

        private PayslipModelMappers()
        {
        }

        public static PayslipModelMappers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayslipModelMappers();
                }

                return _instance;
            }
        }

        public List<PayslipModel> MapToPayslipModels(SqlDataReader sqlDataReader)
        {
            List<PayslipModel> payslipModels = new List<PayslipModel>();

            using (sqlDataReader)
            {
                while (sqlDataReader.Read())
                {
                    PayslipModel payslipModel = new PayslipModel();

                    payslipModel.EmployeeId = sqlDataReader["Id"].ToInteger();
                    payslipModel.Period = sqlDataReader["PaySlipDate"].ToString();
                    payslipModel.Date = sqlDataReader["PaySlipPeriod"].ToString();
                    payslipModel.TotalGrossEarnings = sqlDataReader["TotalGrossEarnings"].ToDecimal();
                    payslipModel.TotalDeductions = sqlDataReader["TotalDeductions"].ToDecimal();
                    payslipModel.NetPayAmount = sqlDataReader["NetPayAmount"].ToDecimal();

                    payslipModels.Add(payslipModel);
                }

                sqlDataReader.NextResult();

                while (sqlDataReader.Read())
                {
                    int employeeId = sqlDataReader["Id"].ToInteger();
                    PayslipModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

                    if (payslipModel != null)
                    {
                        payslipModel.Company = PayslipCompanyModelMappers.Instance.MapToPayslipCompanyModel(sqlDataReader);
                        payslipModel.Employee = PayslipEmployeeModelMappers.Instance.MapToPayslipEmployeeModel(sqlDataReader);
                    }
                }

                sqlDataReader.NextResult();

                while (sqlDataReader.Read())
                {
                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
                    PayslipModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

                    if (payslipModel != null)
                    {
                        payslipModel.IncomeDetails.Add(IncomeDetailModelMappers.Instance.MapToIncomeDetailModel(sqlDataReader));
                    }
                }

                sqlDataReader.NextResult();

                while (sqlDataReader.Read())
                {
                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
                    PayslipModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

                    if (payslipModel != null)
                    {
                        payslipModel.CompanyContributionDetails.Add(CompanyContributionDetailModelMappers.Instance.MapToCompanyContributionDetailModel(sqlDataReader));
                    }
                }

                sqlDataReader.NextResult();

                while (sqlDataReader.Read())
                {
                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
                    PayslipModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

                    if (payslipModel != null)
                    {
                        payslipModel.DeductionDetails.Add(DeductionDetailModelMappers.Instance.MapToDeductionDetailModel(sqlDataReader));
                    }
                }
            }

            return payslipModels;
        }

        public PayslipModel MapToPayslipModel(SqlDataReader sqlDataReader)
        {
            PayslipModel payslipModel = new PayslipModel();

            using (sqlDataReader)
            {
                if (sqlDataReader.Read())
                {
                    payslipModel.EmployeeId = sqlDataReader["Id"].ToInteger();
                    payslipModel.Period = sqlDataReader["PaySlipDate"].ToString();
                    payslipModel.Date = sqlDataReader["PaySlipPeriod"].ToString();
                    payslipModel.TotalGrossEarnings = sqlDataReader["TotalGrossEarnings"].ToDecimal();
                    payslipModel.TotalDeductions = sqlDataReader["TotalDeductions"].ToDecimal();
                    payslipModel.NetPayAmount = sqlDataReader["NetPayAmount"].ToDecimal();

                    sqlDataReader.NextResult();

                    if (sqlDataReader.Read())
                    {
                        payslipModel.Company = PayslipCompanyModelMappers.Instance.MapToPayslipCompanyModel(sqlDataReader);
                        payslipModel.Employee = PayslipEmployeeModelMappers.Instance.MapToPayslipEmployeeModel(sqlDataReader);
                    }

                    sqlDataReader.NextResult();

                    while (sqlDataReader.Read())
                    {
                        payslipModel.IncomeDetails.Add(IncomeDetailModelMappers.Instance.MapToIncomeDetailModel(sqlDataReader));
                    }

                    sqlDataReader.NextResult();

                    while (sqlDataReader.Read())
                    {
                        payslipModel.CompanyContributionDetails.Add(CompanyContributionDetailModelMappers.Instance.MapToCompanyContributionDetailModel(sqlDataReader));
                    }

                    sqlDataReader.NextResult();

                    while (sqlDataReader.Read())
                    {
                        payslipModel.DeductionDetails.Add(DeductionDetailModelMappers.Instance.MapToDeductionDetailModel(sqlDataReader));
                    }
                }
            }

            return payslipModel;
        }
    }
}
