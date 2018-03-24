using Microsoft.AspNetCore.Mvc;

using SqsLibraries.Common.Extensions;

using System.Security.Claims;

namespace DotNetCorePayroll.Api.Extensions
{
    public class BaseController: Controller
    {
        protected virtual ClaimsIdentity CurrentUser
        {
            get { return User.Identity as ClaimsIdentity; }
        }

        protected virtual long? UserId
        {
            get
            {
                Claim userIdClaim = User.Claims.GetClaimType(ClaimTypes.Name);

                if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
                {
                    return null;
                }

                return userIdClaim.Value.ToLong();
            }
        }
    }
}
