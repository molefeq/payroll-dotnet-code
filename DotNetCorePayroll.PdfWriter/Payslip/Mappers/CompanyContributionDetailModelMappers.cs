////using Libraries.Common.Extensions;

//using DotNetCorePayroll.PdfWriter.Models;

//using System.Data.SqlClient;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
//{
//    public class CompanyContributionDetailModelMappers
//    {
//        private static CompanyContributionDetailModelMappers _instance;

//        private CompanyContributionDetailModelMappers()
//        {
//        }

//        public static CompanyContributionDetailModelMappers Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new CompanyContributionDetailModelMappers();
//                }

//                return _instance;
//            }
//        }

//        public CompanyContributionDetailModel MapToCompanyContributionDetailModel(SqlDataReader sqlDataReader)
//        {
//            CompanyContributionDetailModel companyContributionDetailModel = new CompanyContributionDetailModel();

//            companyContributionDetailModel.Description = sqlDataReader["Description"].ToString();
//            companyContributionDetailModel.Amount = sqlDataReader["Amount"].ToDecimal();

//            return companyContributionDetailModel;
//        }
//    }
//}
