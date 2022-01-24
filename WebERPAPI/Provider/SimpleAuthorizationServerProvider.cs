using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using WebERPAPI.BusinessLogic.User;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.DTO.User;

namespace WebERPAPI.Provider
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private readonly int MAX_TIMEOUT_SECONDS = 900000;

        private UserAccountService service = new UserAccountService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            tblUser user = new tblUser();
            user.UserCode = Scripting.validateLoginString(context.UserName);
            user.Password = context.Password;

            var st = new LPLERP.Common.Encryption().EncryptWord("e0LZ0G*#%B9)G9}P95");

            LoggedUserDetails userDetails = service.ValidateUserLogin(user);
            if (userDetails == null)
            {
                context.SetError("Invalid user code or password. Please type correctly.");
                return;
            }

            ClaimsIdentity oAuthIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(userDetails, "", context.UserName);
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,
            string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            if (context.TokenIssued)
            {
                context.Properties.ExpiresUtc = DateTimeOffset.Now.AddSeconds(MAX_TIMEOUT_SECONDS);
            }

            return Task.FromResult<object>(null);
        }

        //public override Task ValidateClientAuthentication
        //(OAuthValidateClientAuthenticationContext context)
        //{
        //    // Resource owner password credentials does not provide a client ID.
        //    if (context.ClientId == null)
        //    {
        //        context.Validated();
        //    }

        //    return Task.FromResult<object>(null);
        //}

        public override Task ValidateClientRedirectUri
        (OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(LoggedUserDetails user, string ClientIP, string userName)
        {
            new UserAccountService().updateLogDetails(new ClientDetails { IPAddress = ClientIP, UserID = user.UserId.GetValueOrDefault() });

            string ID = "", UserID = "", UserCode = "", EmployeeID = "", EmployeeName = "", Firstname = "",
                Department = "", LocationCode = "", Email = "", Designation = "", ProfileImagename = "",
                SignatureFilename = "", DepotCode = "", LocationLevel = "", Mobile = "", dob = "",
                ApplicationID = "", AppName = "", DashboardRoute = "", LocationName = "", OfficeLocationID = "";

            if (user.ID != null) ID = user.ID.ToString();
            if (user.UserId != null) UserID = user.UserId.ToString();
            if (user.UserCode != null) UserCode = user.UserCode;
            if (user.FirstName != null) Firstname = user.FirstName;
            if (user.EmployeeName != null) EmployeeName = user.EmployeeName;
            if (user.EmployeeID != null) EmployeeID = user.EmployeeID;
            if (user.Email != null) Email = user.Email;
            //if (user.Mobile != null) Mobile = user.mobi;
            if (user.Department != null) Department = user.Department;
            if (user.Designation != null) Designation = user.Designation;

            if (user.DepotCode != null) DepotCode = user.DepotCode;
            if (user.LocationCode != null) LocationCode = user.LocationCode;
            if (user.LocationLevel != null) LocationLevel = user.LocationLevel;

            if (user.ProfileImagename != null) ProfileImagename = user.ProfileImagename;
            if (user.SignatureFilename != null) SignatureFilename = user.SignatureFilename;
            if (user.DOB != null) dob = user.DOB.GetValueOrDefault().ToString();
            if (user.ApplicationID != null) ApplicationID = user.ApplicationID.GetValueOrDefault().ToString();
            if (user.AppName != null) AppName = user.AppName.ToString();
            if (user.DashboardRoute != null) DashboardRoute = user.DashboardRoute.ToString();
            if (user.OfficeLocationID != null) OfficeLocationID = user.OfficeLocationID.ToString();
            if (user.LocationName != null) LocationName = user.LocationName.ToString();

            IDictionary<string, string>
            data = new Dictionary<string, string>
            {
                { "id", ID },
                { "userid", UserID },
                { "usercode", UserCode },
                { "firstname", Firstname },
                { "employeename", EmployeeName},
                { "employeeid", EmployeeID},

                { "depotcode", DepotCode },
                { "locationcode", LocationCode },
                { "locationlevel", LocationLevel },

                { "locationname", LocationName},
                { "department", Department},
                { "designation", Designation},
                { "email", Email},
                { "mobile", Mobile},
                { "profileimagename", ProfileImagename},
                { "signaturefilename", SignatureFilename},
                { "dob", dob},
                { "applicationid", ApplicationID},
                { "defaultappname", AppName},
                { "dashboardroute", DashboardRoute},
                { "officelocationid", OfficeLocationID},
            };
            return new AuthenticationProperties(data);
        }
    }
}