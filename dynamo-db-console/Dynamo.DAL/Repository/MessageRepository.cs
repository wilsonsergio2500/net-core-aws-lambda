using Dynamo.DAL.Repository.Base;
using Dynamo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using ServiceStack.Aws.DynamoDb;
using Dynamo.DAL.Client;

namespace Dynamo.DAL.Repository
{
    public class MessageRepository : BaseRepository<Message>
    {
        public MessageRepository(IDynamoDb dynamodb, IDynamoClient dynamoClient) : base(dynamodb, dynamoClient)
        {
        }
    }
}
