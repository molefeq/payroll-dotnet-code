using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class OrganisationAdapter
    {
        public void Update(Organisation organisation, OrganisationModel organisationModel)
        {
            organisation.Name = organisationModel.Name;
            organisation.Description = organisationModel.Description;
            organisation.FaxNumber = organisationModel.FaxNumber;
            organisation.ContactNumber = organisationModel.ContactNumber;
            organisation.EmailAddress = organisationModel.EmailAddress;
            organisation.LogoFilename = organisationModel.LogoFileName;

            organisation.PhysicalAddress.Line1 = organisationModel.PhysicalAddressLine1;
            organisation.PhysicalAddress.Line2 = organisationModel.PhysicalAddressLine2;
            organisation.PhysicalAddress.Suburb = organisationModel.PhysicalAddressSuburb;
            organisation.PhysicalAddress.City = organisationModel.PhysicalAddressCity;
            organisation.PhysicalAddress.PostalCode = organisationModel.PhysicalAddressPostalCode;
            organisation.PhysicalAddress.ProvinceId = organisationModel.PhysicalAddressProvinceId;
            organisation.PhysicalAddress.CountryId = organisationModel.PhysicalAddressCountryId;

            if (organisation.PostalAddress != null)
            {
                organisation.PostalAddress.Line1 = organisationModel.PostalAddressLine1;
                organisation.PostalAddress.Line2 = organisationModel.PostalAddressLine2;
                organisation.PostalAddress.Suburb = organisationModel.PostalAddressSuburb;
                organisation.PostalAddress.City = organisationModel.PostalAddressCity;
                organisation.PostalAddress.PostalCode = organisationModel.PostalAddressPostalCode;
                organisation.PostalAddress.ProvinceId = organisationModel.PostalAddressProvinceId;
                organisation.PostalAddress.CountryId = organisationModel.PostalAddressCountryId;
            }

        }
    }
}
