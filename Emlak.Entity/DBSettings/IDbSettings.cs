using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.DBSettings
{
    public interface IDbSettings
    {
        public string AgentCollectionName { get; set; }
        public string AmenityCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string PropertyCollectionName { get; set; }
        public string PropertyImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
