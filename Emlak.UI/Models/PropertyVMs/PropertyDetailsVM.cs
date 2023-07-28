using Emlak.Entity.Concrete;

namespace Emlak.UI.Models.PropertyVMs
{
    public class PropertyDetailsVM
    {
        public string PropertyID { get; set; } = string.Empty;

        public string Adress { get; set; } = string.Empty;

        public int Rooms { get; set; }

        public int Baths { get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;



        public Agent? Agent { get; set; } = new Agent();
        public string? AgentId { get; set; }
    }
}
