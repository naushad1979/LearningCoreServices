using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace Supplier.Api.Models
{
    public class Supplier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }
        public string SupplierId { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime DateUpdated { get; set; }
        [JsonIgnore]
        public bool Active { get; set; }
        public PersonalInfo PersonalDetail { get; set; }
        public ContactInfo ContactDetail { get; set; }
        public AdditionalInfo AdditionalDetail { get; set; }
    }
}
