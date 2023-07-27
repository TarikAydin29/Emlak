using Emlak.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DTO.DTOs.PropertyDtos
{
    public class PropertyWithAgentDTO : Property
    {
        public List<Agent> Agents { get; set; }

    }
}
