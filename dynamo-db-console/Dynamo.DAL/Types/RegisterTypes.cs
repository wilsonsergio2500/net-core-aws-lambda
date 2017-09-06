using Dynamo.Models;
using System;
using System.Collections.Generic;
using ServiceStack.Aws.DynamoDb;
using System.Text;

namespace Dynamo.DAL.Types
{
    
    public static class DbTypes {
        public static List<Type> Types = new List<Type>() { typeof(Message) };
    }

    public class RegisterTypes
    {
        public RegisterTypes(IDynamoDb dynamodb) {

            foreach (Type t in DbTypes.Types) {
                dynamodb.Db.RegisterTable(t);
            }

            dynamodb.Db.InitSchema();
        }
    }
}
