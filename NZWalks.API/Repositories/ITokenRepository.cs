using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public interface ITokenRepository
    {

        

                
        string CreateJWTToken(IdentityUser user,List<string> roles);

        
    }
}
