using Emlak.Entity.Concrete;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Emlak.UI.Models.PropertyVMs
{
    public class CreatePropertyVM
    {
        public string Adress { get; set; } = string.Empty;
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public decimal Area { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

  
        public string? AgentId { get; set; }
    }
}
