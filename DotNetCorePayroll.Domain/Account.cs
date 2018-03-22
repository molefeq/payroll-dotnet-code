using System;

namespace DotNetCorePayroll.Data
{
    public class Account
    {
        public Account() { }

        public long Id { get; set; }
        public long OrganisationId { get; set; }
        public long? CompanyId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public long RoleId { get; set; }
        public Guid Guid { get; set; }
        public DateTime? DisableDate { get; set; }
        public DateTime CreateDate { get; set; }
        public long? CreateUserId { get; set; }
        public bool IsFirstTimeLogin { get; set; }
        public Guid? PasswordResetKey { get; set; }

        public Company Company { get; set; }
        public Account CreateUser { get; set; }
        public Organisation Organisation { get; set; }
        public Role Role { get; set; }
    }
}
