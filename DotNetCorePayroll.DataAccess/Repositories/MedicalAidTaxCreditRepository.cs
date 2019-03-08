using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class MedicalAidTaxCreditRepository : GenericRepository<MedicalAidTaxCredit>
    {
        private static string MAIN_MEMBER = "MAIN_MEMBER";
        private static string FIRST_DEPENDANT = "FIRST_DEPENDANT";
        private static string OTHER_DEPENDANT = "MAIN_MEMBER";

        public MedicalAidTaxCreditRepository() : base() { }
        public MedicalAidTaxCreditRepository(PayrollContext context) : base(context) { }

        public MedicalAidTaxCredit GetMainMemberMedicalCredit(string year)
        {
            return GetById(item => MAIN_MEMBER.Equals(item.MemberType) && year.Equals(item.Year));
        }

        public MedicalAidTaxCredit GetFirstDependantMedicalCredit(string year)
        {
            return GetById(item => FIRST_DEPENDANT.Equals(item.MemberType) && year.Equals(item.Year));
        }

        public MedicalAidTaxCredit GetOtherDependantMedicalCredit(string year)
        {
            return GetById(item => OTHER_DEPENDANT.Equals(item.MemberType) && year.Equals(item.Year));
        }
    }
}

