using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.Concrete
{
    public class Amenity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AmenityID { get; set; }
        public string Name { get; set; }        
    }
}
