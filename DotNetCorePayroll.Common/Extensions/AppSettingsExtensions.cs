﻿using Microsoft.Extensions.Configuration;

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

        #region Employee Normal Image Information 

        public static string EmployeeTempDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:tempdirectory"];
        }

        public static string EmployeeDirectory(this IConfiguration configuration)
        {
            return configuration["logos:employee:directory"];
        }

        public static int EmployeeImageWidth(this IConfiguration configuration)
        {
            return configuration["logos:employee:width"].ToInteger();
        }

        public static int EmployeeImageHeight(this IConfiguration configuration)
        {
            return configuration["logos:employee:height"].ToInteger();
        }

        #endregion

        #region Email Settings

        public static string SmtpAddress(this IConfiguration configuration)
        {
            return configuration["email:smtpaddress"];
        }

        public static int SmtpPortNumber(this IConfiguration configuration)
        {
            return configuration["email:smtpportnumber"].ToInteger();
        }

        public static string FromAddress(this IConfiguration configuration)
        {
            return configuration["email:fromaddress"];
        }

        public static string AdminAddress(this IConfiguration configuration)
        {
            return configuration["email:adminaddress"];
        }

        public static string ErrorReciever(this IConfiguration configuration)
        {
            return configuration["email:errorreciever"];
        }

        public static string ErrorSender(this IConfiguration configuration)
        {
            return configuration["email:errorsender"];
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
