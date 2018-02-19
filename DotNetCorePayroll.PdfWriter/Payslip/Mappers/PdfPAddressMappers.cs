using DotNetCorePayroll.Common.DataTransferObjects;

using DotNetCorePayroll.PdfWriter.Enums;
using DotNetCorePayroll.PdfWriter.Models;
using System.Data.SqlClient;

namespace DotNetCorePayroll.PdfWriter.Payslip.Mappers
{
    public class PdfPAddressMappers
    {
        private static PdfPAddressMappers _instance;

        public static PdfPAddressMappers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PdfPAddressMappers();
                }

                return _instance;
            }
        }

        public PdfPAddress MapFromEmployeeAddress(EmployeeDto employeeDto, AddressType addressType)
        {
            PdfPAddress pdfPAddress = new PdfPAddress();

            if (employeeDto == null || employeeDto.ContactDetail == null)
            {
                return pdfPAddress;
            }

            AddressDto addressDto = addressType == AddressType.PHYSICAL ? employeeDto.ContactDetail.PhysicalAddress : employeeDto.ContactDetail.PostalAddress;

            if (addressDto == null)
            {
                return pdfPAddress;
            }

            pdfPAddress.AddressLine1 = addressDto.Line1;
            pdfPAddress.AddressLine2 = addressDto.Line2;
            pdfPAddress.Suburb = addressDto.Suburb;
            pdfPAddress.City = addressDto.City;
            pdfPAddress.PostalCode = addressDto.PostalCode;

            return pdfPAddress;
        }

        public PdfPAddress MapFromEmployeeAddress(SqlDataReader sqlDataReader, string prefix = "")
        {
            PdfPAddress pdfPAddress = new PdfPAddress();
            
            pdfPAddress.AddressLine1 = sqlDataReader[prefix + "Line1"].ToString();
            pdfPAddress.AddressLine2 = sqlDataReader[prefix + "Line2"].ToString();
            pdfPAddress.Suburb = sqlDataReader[prefix + "Suburb"].ToString();
            pdfPAddress.City = sqlDataReader[prefix + "City"].ToString();
            pdfPAddress.PostalCode = sqlDataReader[prefix + "PostalCode"].ToString();

            return pdfPAddress;
        }
    }
}
