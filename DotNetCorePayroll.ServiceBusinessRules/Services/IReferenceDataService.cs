using DotNetCorePayroll.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IReferenceDataService
    {
        StaticDataModel GetStaticData();
        List<ReferenceDataModel> GetCountries();
        List<ReferenceDataModel> GetProvinces();
    }
}
