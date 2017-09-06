using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;

namespace Dynamo.TokenReader
{
    public class JwtTokenReader : IJwTokenReader
    {

        private JwtSecurityTokenHandler tokenHandler { get; set; } 
        public JwtTokenReader()
        {
            tokenHandler =new JwtSecurityTokenHandler();
        }

        public ReadOnlyCollection<Claim> ReadToken(string AuthorizationHeader) {
            string token = AuthorizationHeader.ToString().Replace("Bearer ", "");
            JwtSecurityToken securityToken = tokenHandler.ReadJwtToken(token);
            return new ReadOnlyCollection<Claim>(securityToken.Claims.ToList());
        }

    }
}
