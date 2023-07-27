using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Emlak.UI.Models.AgentVMs
{
    public class CreateAgentVM
    {     
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
