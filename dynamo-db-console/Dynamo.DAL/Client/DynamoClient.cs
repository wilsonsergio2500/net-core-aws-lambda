using Amazon;
using Amazon.DynamoDBv2;
using Dynamo.Models.Configs;
using Microsoft.Extensions.Options;


namespace Dynamo.DAL.Client
{
    public class DynamoClient : IDynamoClient
    {

        private AwsConfig awsConfig { get; set; }
        public IAmazonDynamoDB AmazonClient { get;  internal set; }

        public DynamoClient(IOptions<AwsConfig> config) {
            awsConfig = config.Value;
            AmazonClient = new AmazonDynamoDBClient(awsConfig.awsKey, awsConfig.awsSecret, RegionEndpoint.USWest2);

        }


    }
}
