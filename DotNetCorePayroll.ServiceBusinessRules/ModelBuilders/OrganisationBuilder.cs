using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class OrganisationBuilder
    {
        private AddressBuilder addressBuilder;

        public OrganisationBuilder(AddressBuilder addressBuilder)
        {
            this.addressBuilder = addressBuilder;
        }

        public Organisation Build(OrganisationModel organisationModel)
        {
            Organisation organisation = new Organisation();

            organisation.Guid = Guid.NewGuid();
            organisation.Name = organisationModel.Name;
            organisation.Description = organisationModel.Description;
            organisation.FaxNumber = organisationModel.FaxNumber;
            organisation.ContactNumber = organisationModel.ContactNumber;
            organisation.EmailAddress = organisationModel.EmailAddress;
            organisation.LogoFilename = organisationModel.LogoFileName;

            organisation.PhysicalAddress = addressBuilder.Build(organisationModel.PhysicalAddress);
            organisation.PostalAddress = addressBuilder.Build(organisationModel.PostalAddress);
                        
            return organisation;
        }

        public OrganisationModel BuildModel(Organisation organisation)
        {
            OrganisationModel organisationModel = new OrganisationModel();

            organisationModel.Id = organisation.Id;
            organisationModel.Guid = organisation.Guid;
            organisationModel.Name = organisation.Name;
            organisationModel.Description = organisation.Description;
            organisationModel.FaxNumber = organisation.FaxNumber;
            organisationModel.ContactNumber = organisation.ContactNumber;
            organisationModel.EmailAddress = organisationModel.EmailAddress;
            organisationModel.LogoFileName = organisation.LogoFilename;
            organisationModel.PhysicalAddress = addressBuilder.BuildToModel(organisation.PhysicalAddress);
            organisationModel.PostalAddress = addressBuilder.BuildToModel(organisation.PostalAddress);
            
            return organisationModel;
        }
    }
}
