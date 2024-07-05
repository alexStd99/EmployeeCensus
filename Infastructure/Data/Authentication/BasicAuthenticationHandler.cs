using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using EmployeeCensus.Application.Interfaces;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCensus.Infastructure.Data.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUnitOfWork unitOfWork)
            : base(options, logger, encoder, clock)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out StringValues value))
            {
                Response.Headers["WWW-Authenticate"] = "Basic";
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(value);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(u => u.Username == username);

                if (user == null || user.Password != password)
                {
                    return AuthenticateResult.Fail("Invalid Username or Password");
                }

                var claims = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred during authentication.");
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
    }
}