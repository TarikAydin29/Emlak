using Emlak.Entity.Concrete;

namespace Emlak.UI.Models.AgentVMs
{
    public class AgentWithPropertiesVM
    {
        public Agent Agent { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
