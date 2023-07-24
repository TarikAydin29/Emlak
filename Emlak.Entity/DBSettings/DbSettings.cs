using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.DBSettings
{
    public class DbSettings : IDbSettings
    {
        public string AgentCollectionName { get; set; } = string.Empty;
        public string AmenityCollectionName { get; set; } = string.Empty;
        public string CustomerCollectionName { get; set; } = string.Empty;
        public string PropertyCollectionName { get; set; } = string.Empty;
        public string PropertyImageCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
