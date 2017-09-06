using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Models
{
    [Schema("Messages")]
    public class Message : Base.BaseEntity
    {
        public string Content { get; set; }

        public string Email { get; set; }
    }
}
