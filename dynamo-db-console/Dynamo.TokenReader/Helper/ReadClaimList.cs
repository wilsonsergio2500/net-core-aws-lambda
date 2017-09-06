using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Linq;

namespace Dynamo.TokenReader.Helper
{
    public static class ReadClaimList
    {
        public static string GetClaimValue(this ReadOnlyCollection<Claim> claims, string Type)
        {
            return claims.First(g => g.Type == Type).Value;
        }

        public static List<string> GetClaimValueList(this ReadOnlyCollection<Claim> claims , string Type)
        {
            var claimValue = claims.Where(g => g.Type == Type).Select(k => k.Value).ToList();
            return claimValue;

        }
    }
}
