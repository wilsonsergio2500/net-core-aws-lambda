using ServiceStack.DataAnnotations;

namespace Dynamo.Models.Base
{
    public class BaseEntity
    {
        [AutoIncrement]
        public long Id { get; set; }
    }
}
