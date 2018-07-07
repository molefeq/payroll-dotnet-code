using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;

using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.ReferenceData
{
    public class ReferenceDataService : IReferenceDataService
    {
        private IUnitOfWork unitOfWork;

        public ReferenceDataService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public StaticDataModel GetStaticData()
        {
            return new StaticDataModel
            {
                Countries = GetCountries(),
                Provinces = GetProvinces()
            };
        }

        public List<ReferenceDataModel> GetCountries()
        {
            var countries = unitOfWork.Country.GetEntities();

            return countries.Select(c => new ReferenceDataModel(c.Id, c.Name, c.Code)).ToList();
        }

        public List<ReferenceDataModel> GetProvinces()
        {
            var countries = unitOfWork.Province.GetEntities();

            return countries.Select(p => new ReferenceDataModel(p.Id, p.Name, p.Code)).ToList();
        }
    }
}
