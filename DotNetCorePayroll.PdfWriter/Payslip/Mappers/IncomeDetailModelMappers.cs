//using Libraries.Common.Extensions;

//using DotNetCorePayroll.PdfWriter.Models;

//using System.Data.SqlClient;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
//{
//    public class IncomeDetailModelMappers
//    {
//        private static IncomeDetailModelMappers _instance;

//        private IncomeDetailModelMappers()
//        {
//        }

//        public static IncomeDetailModelMappers Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new IncomeDetailModelMappers();
//                }

//                return _instance;
//            }
//        }


//        public IncomeDetailModel MapToIncomeDetailModel(SqlDataReader sqlDataReader)
//        {
//            IncomeDetailModel incomeDetailModel = new IncomeDetailModel();

//            incomeDetailModel.Description = sqlDataReader["Description"].ToString();
//            incomeDetailModel.Amount = sqlDataReader["Amount"].Todouble();

//            return incomeDetailModel;
//        }
//    }
//}
