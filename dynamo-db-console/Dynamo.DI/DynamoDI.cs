using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.DI
{
    public class DynamoDI : System.Attribute
    {
        public DynamoDI()
        {
            new DI();
        }
    }
}
