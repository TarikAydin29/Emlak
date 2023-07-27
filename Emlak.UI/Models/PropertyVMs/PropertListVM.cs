using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Emlak.UI.Models.PropertyVMs
{
    public class PropertListVM
    {       
        public string PropertyID { get; set; } 
        public string Adress { get; set; }         
        public int Rooms { get; set; }   
        public int Baths { get; set; }       
        public decimal Area { get; set; }  
        public decimal Price { get; set; }       
        public string Description { get; set; }     
                     
        public string? AgentId { get; set; }
    }
}
