using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.Concrete
{

    public class Agent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AgentId { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("surname")]
        public string Surname { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("phonenumber")]
        public string Phonenumber { get; set; } = string.Empty;
        [BsonElement("imageurl")]
        public string ImageUrl { get; set; } = string.Empty;


      
        public List<Property>? Properties { get; set; } 
    }
}
