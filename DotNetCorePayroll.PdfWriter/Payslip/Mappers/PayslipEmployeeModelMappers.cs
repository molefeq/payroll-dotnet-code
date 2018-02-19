using DotNetCorePayroll.PdfWriter.Models;
using Libraries.Common.Extensions;

using System.Data.SqlClient;

namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
{
    public class PayslipEmployeeModelMappers
    {
        private static PayslipEmployeeModelMappers _instance;

        private PayslipEmployeeModelMappers()
        {
        }

        public static PayslipEmployeeModelMappers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayslipEmployeeModelMappers();
                }

                return _instance;
            }
        }

        public PayslipEmployeeModel MapToPayslipEmployeeModel(SqlDataReader sqlDataReader)
        {
            PayslipEmployeeModel payslipEmployeeModel = new PayslipEmployeeModel();

            payslipEmployeeModel.EmployeeNumber = sqlDataReader["Employee_EmployeeNumber"].ToString();
            payslipEmployeeModel.Name = sqlDataReader["Employee_Name"].ToString(); ;
            payslipEmployeeModel.EmailAddress = sqlDataReader["Employee_EmailAddress"].ToString();
            payslipEmployeeModel.Position = sqlDataReader["Employee_Position"].ToString();
            payslipEmployeeModel.IdOrPassportNumber = sqlDataReader["Employee_IdOrPassportNumber"].ToString();
            payslipEmployeeModel.DateOfEngagement = sqlDataReader["Employee_DateOfEngagement"].ToString();
            payslipEmployeeModel.TaxReferenceNumber = sqlDataReader["Employee_TaxReferenceNumber"].ToString();

            return payslipEmployeeModel;
        }
    }
}
