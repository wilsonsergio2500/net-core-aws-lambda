using Dynamo.TokenReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Security.Claims;
using Dynamo.TokenReader.Helper;
using System.Linq;
using System.Collections.Generic;

namespace Dynamo.DAL.TEST.TokenReader
{
    [TestClass]
    public class TokenReaderrTest
    {
        [TestMethod]
        public void CanReadToken() {
            string token = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Im15OWxsd3U5Q3o1MzZ1TnFWYmt6N3o1QXdfYyIsImtpZCI6Im15OWxsd3U5Q3o1MzZ1TnFWYmt6N3o1QXdfYyJ9.eyJpc3MiOiJodHRwczovL2xvZ2luLmdhbGx1cC5jb20iLCJhdWQiOiJodHRwczovL2xvZ2luLmdhbGx1cC5jb20vcmVzb3VyY2VzIiwiZXhwIjoxNTAzNDM3OTQyLCJuYmYiOjE1MDM0MzQzNDIsImdhbGx1cF9jbGllbnRfaWQiOiI1MTkxIiwib21zX2NsaWVudF9uYW1lIjoiVEVTVERBVEEiLCJzZXNzaW9uX2lkIjoiNDViMDIyM2QxMWZhNGM3Nzg2NTUyMmE2NzY5MDZiYjMiLCJ2ZXJzaW9uIjoiMS4wLjAuMCIsInN1YiI6IjEyODI1NjUiLCJpZCI6IjEyODI1NjUiLCJ1c2VybmFtZSI6ImF1Z3VzdHRlc3QiLCJuYW1lIjoiYXVndXN0dGVzdCIsImdpdmVuX25hbWUiOiJBdWd1c3QiLCJmYW1pbHlfbmFtZSI6IlRlc3QiLCJlbWFpbCI6ImF1Z3VzdHRlc3RAbWFpbGluYXRvci5jb20iLCJjb3VudHJ5IjoiVVNBIiwibWVtYmVyX2lkIjoiMTI4Mjg2MiIsImNsaWVudF9pZCI6IkdhbGx1cC5JZGVudGl0eVNlcnZlciIsInNjb3BlIjpbImdhbGx1cF9jbGllbnRfY29udGV4dCIsIm9mZmxpbmVfYWNjZXNzIiwicHJpdmlsZWdlcyIsInByb2ZpbGVfZXh0ZW5kZWQiLCJyb2xlcyIsInRlYW0iLCJvcGVuaWQiLCJwcm9maWxlIiwiZW1haWwiXSwiYXV0aF90aW1lIjoxNTAzNDM0MTk3LCJpZHAiOiJpZHNydiIsInByaXZpbGVnZSI6WyJzZl90b3BfNSIsInNmX2luZGl2aWR1YWxfY29udGVudCIsImFvbCIsImFvbF9sZWFybiJdLCJyb2xlIjoic2ZfdG9wXzUiLCJhbXIiOlsicGFzc3dvcmQiXX0.cr6SU8qAr3DIBi-3VkhiOJWnc7h3sHY-nT-Gk0_pJVxtUJep5S1DhNqOwIfp9q2Vg5IrIcx7xfGYJyOox4_wf-oapyccBa6nYgrV6SDop2c4t-2FbINAyCSsKte0LwJfq_JtQ27UxyExxEoibf6qDJTjsk-ZQPz0awa3r6WcQlHaxks0bIDqcxkU_Ywrj1Hd7J-zbjdGkA9IVWsd8PLGU2kxx1iIaZ1Zfv1k33N4fg_-lY6Vk9ikeVwdQdnMmtCqAty1E6bs3vptQx63YIiAhB4rtxPQUxI4NV9e2St-kEAzHGTdbwv0p9nbW5bn_zfPpw_Vi88Ahsse8EAfCmb3yg";

            IServiceProvider sp = StartUp.ServiceProvider;
            IJwTokenReader tokenReader = sp.GetService<IJwTokenReader>();
            ReadOnlyCollection<Claim> claims = tokenReader.ReadToken(token);
            string clientID = claims.GetClaimValue(ClaimList.GallupClientId);
            List<string> roles = claims.GetClaimValueList(ClaimList.Role);
            Assert.IsNotNull(clientID);
        }
    }
}
