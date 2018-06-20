using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class OrganisationBuilder
    {
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
            
            organisation.PhysicalAddress = new Address
            {
                Line1 = organisationModel.PhysicalAddressLine1,
                Line2 = organisationModel.PhysicalAddressLine2,
                Suburb = organisationModel.PhysicalAddressSuburb,
                City = organisationModel.PhysicalAddressCity,
                PostalCode = organisationModel.PhysicalAddressPostalCode
            };

            organisation.PostalAddress = new Address
            {
                Line1 = organisationModel.PostalAddressLine1,
                Line2 = organisationModel.PostalAddressLine2,
                Suburb = organisationModel.PostalAddressSuburb,
                City = organisationModel.PostalAddressCity,
                PostalCode = organisationModel.PostalAddressPostalCode
            };
            
            return organisation;
        }

        public OrganisationModel BuildModel(Organisation organisation)
        {
            OrganisationModel organisationModel = new OrganisationModel();

            organisationModel.Id = organisation.Guid;
            organisationModel.Name = organisation.Name;
            organisationModel.Description = organisation.Description;
            organisationModel.FaxNumber = organisation.FaxNumber;
            organisationModel.ContactNumber = organisation.ContactNumber;
            organisationModel.EmailAddress = organisationModel.EmailAddress;
            organisationModel.LogoFileName = organisation.LogoFilename;
            organisationModel.PhysicalAddressId = organisation.PhysicalAddressId;

            if (organisation.PhysicalAddress != null)
            {
                organisationModel.PhysicalAddressLine1 = organisation.PhysicalAddress.Line1;
                organisationModel.PhysicalAddressLine2 = organisation.PhysicalAddress.Line2;
                organisationModel.PhysicalAddressSuburb = organisation.PhysicalAddress.Suburb;
                organisationModel.PhysicalAddressCity = organisation.PhysicalAddress.City;
                organisationModel.PhysicalAddressPostalCode = organisation.PhysicalAddress.PostalCode;
            }

            organisationModel.PostalAddressId = organisation.PostalAddressId;
            if (organisation.PostalAddress != null)
            {
                organisationModel.PostalAddressLine1 = organisation.PostalAddress.Line1;
                organisationModel.PostalAddressLine2 = organisation.PostalAddress.Line2;
                organisationModel.PostalAddressSuburb = organisation.PostalAddress.Suburb;
                organisationModel.PostalAddressCity = organisation.PostalAddress.City;
                organisationModel.PostalAddressPostalCode = organisation.PostalAddress.PostalCode;
            }
            
            return organisationModel;
        }
    }
}
