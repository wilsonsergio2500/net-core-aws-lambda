using Amazon.DynamoDBv2;
using Dynamo.DAL.Client;
using Dynamo.DAL.Helpers;
using Dynamo.DAL.Interfaces;
using Dynamo.Models.Base;
using ServiceStack.Aws.DynamoDb;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.DAL.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity, new()
    {
        private IPocoDynamo DynamoDb { get; set; }
        private IAmazonDynamoDB AmazonDbClient { get; set; }
        public BaseRepository(IDynamoDb dynamodb, IDynamoClient dynamoClient) {

            DynamoDb = dynamodb.Db;
            AmazonDbClient = dynamoClient.AmazonClient;

        }


        public T Add(T Element) {
           
                DynamoDb.PutItem(Element);
                return Element;
        }

        public T Get(long Id) {

            try
            {
                T item = DynamoDb.GetItem<T>(Id);
                return item;
            }
            catch  {
                return null;
            }
            
        }

        public List<T> GetAll() {
            try
            {
                List<T> Items = DynamoDb.GetAll<T>();

                return Items;
            }
            catch (Exception ex) {

                return new List<T>();
            }
        }
    }
}
