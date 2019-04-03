using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;

using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.ReferenceData
{
    public class ReferenceDataService : IReferenceDataService
    {
        private static string TITLE_TPYE = "TITLE";
        private static string MARITAL_STATUS_TPYE = "MARITAL_STATUS";
        private static string ETHNIC_GROUP_TPYE = "ETHNIC_GROUP";
        private static string LANGUAGE_TPYE = "LANGUAGE";
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
                Provinces = GetProvinces(),
                Titles = GeTitles(),
                MaritalStatuses = GetMaritalStatuses(),
                EthnicGroups = GetEthnicGroups(),
                Languages = GetLanguages()
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

        public List<ReferenceDataModel> GeTitles()
        {
            var items = unitOfWork.Lookup.GetEntities(item=> TITLE_TPYE.Equals(item.Type));

            return items.Select(p => new ReferenceDataModel(p.Value, p.Code)).ToList(); 
        }

        public List<ReferenceDataModel> GetMaritalStatuses()
        {
            var items = unitOfWork.Lookup.GetEntities(item => MARITAL_STATUS_TPYE.Equals(item.Type));

            return items.Select(p => new ReferenceDataModel(p.Value, p.Code)).ToList();
        }

        public List<ReferenceDataModel> GetEthnicGroups()
        {
            var items = unitOfWork.Lookup.GetEntities(item => ETHNIC_GROUP_TPYE.Equals(item.Type));

            return items.Select(p => new ReferenceDataModel(p.Value, p.Code)).ToList();
        }

        public List<ReferenceDataModel> GetLanguages()
        {
            var items = unitOfWork.Lookup.GetEntities(item => LANGUAGE_TPYE.Equals(item.Type));

            return items.Select(p => new ReferenceDataModel(p.Value, p.Code)).ToList();
        }
    }
}
