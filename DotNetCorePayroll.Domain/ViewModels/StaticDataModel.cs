using System.Collections.Generic;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class StaticDataModel
    {
        public List<ReferenceDataModel> Provinces { get; set; }
        public List<ReferenceDataModel> Countries { get; set; }
    }
}
