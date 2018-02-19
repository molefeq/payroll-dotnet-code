using Libraries.Common.Extensions;

using DotNetCorePayroll.PdfWriter.Models;

using System.Data.SqlClient;

namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
{
    public class PayslipCompanyModelMappers
    {
        private static PayslipCompanyModelMappers _instance;

        private PayslipCompanyModelMappers()
        {
        }

        public static PayslipCompanyModelMappers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayslipCompanyModelMappers();
                }

                return _instance;
            }
        }

        public PayslipCompanyModel MapToPayslipCompanyModel(SqlDataReader sqlDataReader)
        {
            PayslipCompanyModel payslipCompanyModel = new PayslipCompanyModel();

            payslipCompanyModel.Address = PdfPAddressMappers.Instance.MapFromEmployeeAddress(sqlDataReader, "Company_PhysicalAddress");
            payslipCompanyModel.TelephoneNumber = sqlDataReader["Company_TelephoneNumber"].ToString();
            payslipCompanyModel.EmailAddress = sqlDataReader["Company_EmailAddress"].ToString();
            payslipCompanyModel.Name = sqlDataReader["Company_Name"].ToString();
            payslipCompanyModel.RegistrationNumber = sqlDataReader["Company_RegistrationNumber"].ToString();

            return payslipCompanyModel;
        }
    }
}
