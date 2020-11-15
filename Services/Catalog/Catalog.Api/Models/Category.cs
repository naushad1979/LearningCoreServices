using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Catalog.Api.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryTitle { get; set; }
        public string IconName { get; set; }

        [JsonIgnore]
        public bool Active { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        public DateTime UpdatedDate { get; set; }
    }
}
