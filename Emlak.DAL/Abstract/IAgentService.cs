using Emlak.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DAL.Abstract
{
    public interface IAgentService
    {
        List<Agent> GetList();
        Agent GetById(string id);
        Agent Add(Agent agent);
        void Update(string id, Agent agent);
        void Delete(string id);
        
    }
}
