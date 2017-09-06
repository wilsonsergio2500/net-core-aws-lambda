using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;

namespace Dynamo.TokenReader
{
    public interface IJwTokenReader
    {
        ReadOnlyCollection<Claim> ReadToken(string token);
    }
}
