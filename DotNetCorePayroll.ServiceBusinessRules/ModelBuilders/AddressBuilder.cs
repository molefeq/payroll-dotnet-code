using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class AddressBuilder
    {
        public Address Build(AddressModel addressModel)
        {
            if (addressModel == null)
            {
                return null;
            }

            Address address = new Address
            {
                Line1 = addressModel.Line1,
                Line2 = addressModel.Line2,
                Suburb = addressModel.Suburb,
                City = addressModel.City,
                ProvinceId = addressModel.ProvinceId,
                CountryId = addressModel.CountryId,
                PostalCode = addressModel.PostalCode,
                Location = addressModel.Location,
            };

            return address;
        }

        public AddressModel BuildToModel(Address address)
        {
            if (address == null)
            {
                return null;
            }

            AddressModel addressModel = new AddressModel
            {
                Id = address.Id,
                Line1 = address.Line1,
                Line2 = address.Line2,
                Suburb = address.Suburb,
                City = address.City,
                ProvinceId = address.ProvinceId,
                CountryId = address.CountryId,
                PostalCode = address.PostalCode,
                Location = address.Location
            };

            return addressModel;
        }
    }
}
