using Emlak.DAL.Abstract;
using Emlak.Entity.Concrete;
using Emlak.Entity.DBSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DAL.Concrete
{
    public class AgentService : IAgentService
    {
        private readonly IMongoCollection<Agent> _agent;
        private readonly IMongoCollection<Property> _property;

        public AgentService(IDbSettings dbSettings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(dbSettings.DatabaseName);
            _agent = db.GetCollection<Agent>(dbSettings.AgentCollectionName);
            _property = db.GetCollection<Property>(dbSettings.PropertyCollectionName);
        }
        public Agent Add(Agent agent)
        {
            _agent.InsertOne(agent);
            return agent;
        }

        public void Delete(string id)
        {
            _agent.DeleteOne(x => x.AgentId == id);
        }

        public Agent GetById(string id)
        {
            return _agent.Find(x => x.AgentId == id).FirstOrDefault();
        }

        public List<Agent> GetList()
        {
            return _agent.Find(x => true).ToList();
        }
      

        public void Update(string id, Agent agent)
        {
            _agent.ReplaceOne(x => x.AgentId == id, agent);
        }
    }
}
