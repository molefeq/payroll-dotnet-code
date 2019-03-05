using Microsoft.Extensions.Configuration;
using SqsLibraries.Common.Email.Models;
using SqsLibraries.Common.Extensions;

namespace DotNetCorePayroll.Common.Extensions
{
    public static class AppSettingsExtensions
    {
        #region Organisation Preview Image Information 

        public static string OrganisationPreviewDirectory(this IConfiguration configuration)
        {
            return configuration["logos:organisation:preview:directory"];
        }

        public static int OrganisationPreviewImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:organisation:preview:width"].ToInteger();
        }

        public static int OrganisationPreviewImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:organisation:preview:height"].ToInteger();
        }

        #endregion

        #region Organisation Normal Image Information 

        public static string OrganisationNormalTempDirectory(this IConfiguration configuration)
        {
            return configuration["logos:organisation:normal:tempdirectory"];
        }

        public static string OrganisationNormalDirectory(this IConfiguration configuration)
        {
            return configuration["logos:organisation:normal:directory"];
        }

        public static int OrganisationNormalImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:organisation:normal:width"].ToInteger();
        }

        public static int OrganisationNormalImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:organisation:normal:height"].ToInteger();
        }

        #endregion

        #region Organisation Thumbnail Image Information 

        public static string OrganisationThumbnailDirectory(this IConfiguration configuration)
        {
            return configuration["logos:organisation:thumbnail:directory"];
        }

        public static int OrganisationThumbnailImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:organisation:thumbnail:width"].ToInteger();
        }

        public static int OrganisationThumbnailImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:organisation:thumbnail:height"].ToInteger();
        }

        #endregion

        #region Company Preview Image Information 

        public static string CompanyPreviewDirectory(this IConfiguration configuration)
        {
            return configuration["logos:company:preview:directory"];
        }

        public static int CompanyPreviewImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:company:preview:width"].ToInteger();
        }

        public static int CompanyPreviewImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:company:preview:height"].ToInteger();
        }

        #endregion

        #region Company Normal Image Information 

        public static string CompanyNormalTempDirectory(this IConfiguration configuration)
        {
            return configuration["logos:company:normal:tempdirectory"];
        }

        public static string CompanyNormalDirectory(this IConfiguration configuration)
        {
            return configuration["logos:company:normal:directory"];
        }

        public static int CompanyNormalImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:company:normal:width"].ToInteger();
        }

        public static int CompanyNormalImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:company:normal:height"].ToInteger();
        }

        #endregion

        #region Company Thumbnail Image Information 

        public static string CompanyThumbnailDirectory(this IConfiguration configuration)
        {
            return configuration["logos:company:thumbnail:directory"];
        }

        public static int CompanyThumbnailImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:company:thumbnail:width"].ToInteger();
        }

        public static int CompanyThumbnailImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:company:thumbnail:height"].ToInteger();
        }

        #endregion


        #region Employee Preview Image Information 
        
        public static string EmployeePreviewDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:directory"];
        }

        public static int EmployeePreviewImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:employee:width"].ToInteger();
        }

        public static int EmployeePreviewImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:employee:height"].ToInteger();
        }

        #endregion

        #region Employee Normal Image Information 

        public static string EmployeeNormalTempDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:tempdirectory"];
        }

        public static string EmployeeNormalDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:directory"];
        }

        public static int EmployeeNormalImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:employee:width"].ToInteger();
        }

        public static int EmployeeNormalImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:employee:height"].ToInteger();
        }

        #endregion

        #region Employee Thumbnail Image Information 

        public static string EmployeeThumbnailDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:directory"];
        }

        public static int EmployeeThumbnailImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:employee:width"].ToInteger();
        }

        public static int EmployeeThumbnailImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:employee:height"].ToInteger();
        }

        #endregion


        #region Email Settings

        public static EmailConfiguration EmailConfiguration(this IConfiguration configuration)
        {
            return new EmailConfiguration
            {
                SmtpServer = configuration["email:configuration:smtpserver"],
                SmtpPortNumber = configuration["email:configuration:smtpport"].ToInteger(),
                Username = configuration["email:configuration:username"],
                Password = configuration["email:configuration:password"]
            };
        }

        public static EmailAddress InfoAddress(this IConfiguration configuration)
        {
            return new EmailAddress
            {
                Address = configuration["email:infofrom:address"],
                Name = configuration["email:infofrom:name"]
            };
        }

        public static EmailAddress ErrorAddress(this IConfiguration configuration)
        {
            return new EmailAddress
            {
                Address = configuration["email:error:address"],
                Name = configuration["email:error:name"]
            };
        }

        #endregion

        public static string SiteUrl(this IConfiguration configuration)
        {
            return configuration["site:url"];
        }

        public static string SiteName(this IConfiguration configuration)
        {
            return configuration["site:name"];
        }

        public static string PasswordResetUrl(this IConfiguration configuration)
        {
            return configuration["site:passwordreseturl"];
        }

        public static string ApplicationName(this IConfiguration configuration)
        {
            return configuration["applicationname"];
        }
    }
}
