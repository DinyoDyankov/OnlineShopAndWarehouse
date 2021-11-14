using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace OnlineShopAndWarehouse.Services.Identity
{
    public class UserService : IUserService
    {
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor
                .HttpContext?
                .User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string UserId { get; }
    }
}
