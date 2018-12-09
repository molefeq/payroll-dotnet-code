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
            AddressModel addressModel = new AddressModel();

            if (address == null)
            {
                return addressModel;
            }

            addressModel.Id = address.Id;
            addressModel.Line1 = address.Line1;
            addressModel.Line2 = address.Line2;
            addressModel.Suburb = address.Suburb;
            addressModel.City = address.City;
            addressModel.ProvinceId = address.ProvinceId;
            addressModel.CountryId = address.CountryId;
            addressModel.PostalCode = address.PostalCode;
            addressModel.Location = address.Location;

            return addressModel;
        }
    }
}
