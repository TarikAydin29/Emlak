﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.Concrete
{
    [BsonIgnoreExtraElements]
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PropertyID { get; set; } = string.Empty;
        [BsonElement("adress")]
        public string Adress { get; set; } = string.Empty;
        [BsonElement("rooms")]
        public int Rooms { get; set; }
        [BsonElement("baths")]
        public int Baths { get; set; }
        [BsonElement("area")]
        public decimal Area { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;
        //public DateTime CreatedDate { get; set; }

        //public int AgentID { get; set; }


        //public Agent Agent { get; set; }
        //public ICollection<Amenity>? Amenities { get; set; }
        //public ICollection<PropertyImage> PropertyImages { get; set; }
    }
}