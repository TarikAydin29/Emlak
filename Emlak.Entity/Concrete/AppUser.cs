using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.Concrete
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<Guid>
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("surname")]
        public string Surname { get; set; } = string.Empty;
        [BsonElement("imageurl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
