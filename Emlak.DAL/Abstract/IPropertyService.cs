using Emlak.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DAL.Abstract
{
    public interface IPropertyService
    {
        List<Property> GetList();
        Property GetById(string id);
        Property Add(Property property);
        void Update(string id, Property property);
        void Delete(string id);
    }
}
