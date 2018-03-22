namespace DotNetCorePayroll.Data.ViewModels
{
    public class UserModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public long OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public long? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
