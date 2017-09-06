using ServiceStack.Aws.DynamoDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.DAL
{
    public interface IDynamoDb
    {
        IPocoDynamo Db { get; }

    }
}
