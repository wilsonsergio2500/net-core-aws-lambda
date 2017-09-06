using Dynamo.DAL.Client;
using Dynamo.DAL.Types;
using ServiceStack.Aws.DynamoDb;


namespace Dynamo.DAL
{
    public class DynamoDb : IDynamoDb
    {

        public IPocoDynamo Db { get; internal set; }

        public DynamoDb(IDynamoClient DynamoClient) {
             Db = new PocoDynamo(DynamoClient.AmazonClient);
            new RegisterTypes(this);
        }

    }
}
