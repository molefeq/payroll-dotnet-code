using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class AddressAdapter
    {
        public void Update(Address address, AddressModel addressModel)
        {
            address.Line1 = addressModel.Line1;
            address.Line2 = addressModel.Line2;
            address.Suburb = addressModel.Suburb;
            address.City = addressModel.City;
            address.ProvinceId = addressModel.ProvinceId;
            address.CountryId = addressModel.CountryId;
            address.PostalCode = addressModel.PostalCode;
            address.Location = addressModel.Location;
        }
    }
}
