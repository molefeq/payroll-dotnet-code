using Libraries.Common.Extensions;

using DotNetCorePayroll.PdfWriter.Models;

using System.Data.SqlClient;

namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
{
    public class DeductionDetailModelMappers
    {
        private static DeductionDetailModelMappers _instance;

        private DeductionDetailModelMappers()
        {
        }

        public static DeductionDetailModelMappers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeductionDetailModelMappers();
                }

                return _instance;
            }
        }

        public DeductionDetailModel MapToDeductionDetailModel(SqlDataReader sqlDataReader)
        {
            DeductionDetailModel deductionDetailModel = new DeductionDetailModel();

            deductionDetailModel.Description = sqlDataReader["Description"].ToString();
            deductionDetailModel.Amount = sqlDataReader["Amount"].ToDecimal();

            return deductionDetailModel;
        }
    }
}
