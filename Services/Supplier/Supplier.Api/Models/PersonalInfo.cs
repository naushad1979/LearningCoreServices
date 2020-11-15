using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Supplier.Api.Models
{
    public class PersonalInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }        
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string OfficeName { get; set; }
        public string BusinessEmail { get; set; }
        public string Website { get; set; }        
    }
}
