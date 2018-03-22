using System;

namespace DotNetCorePayroll.Data
{
    public class Company
    {
        public long Id { get; set; }
        public long Organisationid { get; set; }
        public string Name { get; set; }
        public string Registeredname { get; set; }
        public string Tradingname { get; set; }
        public string Natureofbusiness { get; set; }
        public string Companyregistrationnumber { get; set; }
        public string Taxnumber { get; set; }
        public string Uifreferencenumber { get; set; }
        public string Payereferencenumber { get; set; }
        public string Uifcompanyreferencenumber { get; set; }
        public string Sarsuifnumber { get; set; }
        public short Paysdlind { get; set; }
        public string Logofilename { get; set; }
        public Guid Guid { get; set; }

        public Organisation Organisation { get; set; }
    }
}
