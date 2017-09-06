using Amazon.DynamoDBv2;


namespace Dynamo.DAL.Client
{
    public interface IDynamoClient
    {
        IAmazonDynamoDB AmazonClient { get; }
    }
}
