//using Libraries.Common.Extensions;

//using DotNetCorePayroll.PdfWriter.Models;

//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
//{
//    public class PayslipModelMappers
//    {
//        private static PayslipModelMappers _instance;

//        private PayslipModelMappers()
//        {
//        }

//        public static PayslipModelMappers Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new PayslipModelMappers();
//                }

//                return _instance;
//            }
//        }

//        public List<PayslipPdfModel> MapToPayslipModels(SqlDataReader sqlDataReader)
//        {
//            List<PayslipPdfModel> payslipModels = new List<PayslipPdfModel>();

//            using (sqlDataReader)
//            {
//                while (sqlDataReader.Read())
//                {
//                    PayslipPdfModel payslipModel = new PayslipPdfModel();

//                    payslipModel.EmployeeId = sqlDataReader["Id"].ToInteger();
//                    payslipModel.Period = sqlDataReader["PaySlipDate"].ToString();
//                    payslipModel.Date = sqlDataReader["PaySlipPeriod"].ToString();
//                    payslipModel.TotalGrossEarnings = sqlDataReader["TotalGrossEarnings"].Todouble();
//                    payslipModel.TotalDeductions = sqlDataReader["TotalDeductions"].Todouble();
//                    payslipModel.NetPayAmount = sqlDataReader["NetPayAmount"].Todouble();

//                    payslipModels.Add(payslipModel);
//                }

//                sqlDataReader.NextResult();

//                while (sqlDataReader.Read())
//                {
//                    int employeeId = sqlDataReader["Id"].ToInteger();
//                    PayslipPdfModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

//                    if (payslipModel != null)
//                    {
//                        payslipModel.Company = PayslipCompanyModelMappers.Instance.MapToPayslipCompanyModel(sqlDataReader);
//                        payslipModel.Employee = PayslipEmployeeModelMappers.Instance.MapToPayslipEmployeeModel(sqlDataReader);
//                    }
//                }

//                sqlDataReader.NextResult();

//                while (sqlDataReader.Read())
//                {
//                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
//                    PayslipPdfModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

//                    if (payslipModel != null)
//                    {
//                        payslipModel.IncomeDetails.Add(IncomeDetailModelMappers.Instance.MapToIncomeDetailModel(sqlDataReader));
//                    }
//                }

//                sqlDataReader.NextResult();

//                while (sqlDataReader.Read())
//                {
//                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
//                    PayslipPdfModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

//                    if (payslipModel != null)
//                    {
//                        payslipModel.CompanyContributionDetails.Add(CompanyContributionDetailModelMappers.Instance.MapToCompanyContributionDetailModel(sqlDataReader));
//                    }
//                }

//                sqlDataReader.NextResult();

//                while (sqlDataReader.Read())
//                {
//                    int employeeId = sqlDataReader["EmployeeId"].ToInteger();
//                    PayslipPdfModel payslipModel = payslipModels.Where(item => item.EmployeeId == employeeId).FirstOrDefault();

//                    if (payslipModel != null)
//                    {
//                        payslipModel.DeductionDetails.Add(DeductionDetailModelMappers.Instance.MapToDeductionDetailModel(sqlDataReader));
//                    }
//                }
//            }

//            return payslipModels;
//        }

//        public PayslipPdfModel MapToPayslipModel(SqlDataReader sqlDataReader)
//        {
//            PayslipPdfModel payslipModel = new PayslipPdfModel();

//            using (sqlDataReader)
//            {
//                if (sqlDataReader.Read())
//                {
//                    payslipModel.EmployeeId = sqlDataReader["Id"].ToInteger();
//                    payslipModel.Period = sqlDataReader["PaySlipDate"].ToString();
//                    payslipModel.Date = sqlDataReader["PaySlipPeriod"].ToString();
//                    payslipModel.TotalGrossEarnings = sqlDataReader["TotalGrossEarnings"].Todouble();
//                    payslipModel.TotalDeductions = sqlDataReader["TotalDeductions"].Todouble();
//                    payslipModel.NetPayAmount = sqlDataReader["NetPayAmount"].Todouble();

//                    sqlDataReader.NextResult();

//                    if (sqlDataReader.Read())
//                    {
//                        payslipModel.Company = PayslipCompanyModelMappers.Instance.MapToPayslipCompanyModel(sqlDataReader);
//                        payslipModel.Employee = PayslipEmployeeModelMappers.Instance.MapToPayslipEmployeeModel(sqlDataReader);
//                    }

//                    sqlDataReader.NextResult();

//                    while (sqlDataReader.Read())
//                    {
//                        payslipModel.IncomeDetails.Add(IncomeDetailModelMappers.Instance.MapToIncomeDetailModel(sqlDataReader));
//                    }

//                    sqlDataReader.NextResult();

//                    while (sqlDataReader.Read())
//                    {
//                        payslipModel.CompanyContributionDetails.Add(CompanyContributionDetailModelMappers.Instance.MapToCompanyContributionDetailModel(sqlDataReader));
//                    }

//                    sqlDataReader.NextResult();

//                    while (sqlDataReader.Read())
//                    {
//                        payslipModel.DeductionDetails.Add(DeductionDetailModelMappers.Instance.MapToDeductionDetailModel(sqlDataReader));
//                    }
//                }
//            }

//            return payslipModel;
//        }
//    }
//}
