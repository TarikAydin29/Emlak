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
    public class PropertyService : IPropertyService
    {
        private readonly IMongoCollection<Property> _property;

        public PropertyService(IDbSettings dbSettings, IMongoClient mongoClient)
        {
            var db = mongoClient.GetDatabase(dbSettings.DatabaseName);
            _property = db.GetCollection<Property>(dbSettings.PropertyCollectionName);
        }
        public Property Add(Property property)
        {
            _property.InsertOne(property);
            return property;
        }

        public void Delete(string id)
        {
            _property.DeleteOne(x => x.PropertyID == id);
        }

        public Property GetById(string id)
        {
            return _property.Find(x => x.PropertyID == id).FirstOrDefault();
        }

        public List<Property> GetList()
        {
            return _property.Find(x => true).ToList();
        }

        public void Update(string id, Property property)
        {
            _property.ReplaceOne(x => x.PropertyID == id, property);
        }
    }
}
