using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Security.Principal;

namespace JBApp.Models
{
    public class CustomAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {		
        private Dictionary<string, string> _authService;
        public CustomAuthenticationFilterAttribute()
        {
            _authService = new Dictionary<string, string>();
			_authService.Add("123abc", "tung@test.com");
			_authService.Add("456def", "mike@test.com");
        }

        /// <summary>
        /// don't allow this filter to be applied multiple time on the same method/controller
        /// </summary>
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Authenticates the request.
        /// https://dotnetcodr.com/2015/07/23/web-api-2-security-extensibility-points-part-2-custom-authentication-filter/
        /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-filters#implementing-challengeasync
        /// for method that doesn't need authentication then just add attribute [AllowAnonymous]
        /// </summary>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A Task that will perform authentication.
        /// </returns>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                return;
            }

            // 3. If there are credentials but the filter does not recognize the 
            //    authentication scheme, do nothing.
            if (authorization.Scheme != "Bearer")
            {
                return;
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            //validate the key
            if (_authService[authorization.Parameter] != null)
            {
                context.Principal = new GenericPrincipal(
                    new GenericIdentity(_authService[authorization.Parameter]),
                    new string[] { "User" });//set the principal which mean that the key is valid.
                return;
            }
            else
                context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return;//do nothing as we don't return any challenge.
        }
    }
}