using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class OrganisationAdapter
    {
        private AddressBuilder addressBuilder;
        private AddressAdapter addressAdapter;

        public OrganisationAdapter(AddressBuilder addressBuilder, AddressAdapter addressAdapter)
        {
            this.addressBuilder = addressBuilder;
            this.addressAdapter = addressAdapter;
        }

        public void Update(Organisation organisation, OrganisationModel organisationModel)
        {
            organisation.Name = organisationModel.Name;
            organisation.Description = organisationModel.Description;
            organisation.FaxNumber = organisationModel.FaxNumber;
            organisation.ContactNumber = organisationModel.ContactNumber;
            organisation.EmailAddress = organisationModel.EmailAddress;
            organisation.LogoFilename = organisationModel.LogoFileName;

            if (organisation.PostalAddressId == null)
            {
                organisation.PostalAddress = addressBuilder.Build(organisationModel.PostalAddress);
            }
            else
            {
                addressAdapter.Update(organisation.PostalAddress, organisationModel.PostalAddress);
            }

            if (organisation.PhysicalAddress == null)
            {
                organisation.PhysicalAddress = addressBuilder.Build(organisationModel.PhysicalAddress);
            }
            else
            {
                addressAdapter.Update(organisation.PhysicalAddress, organisationModel.PhysicalAddress);
            }
        }
    }
}
