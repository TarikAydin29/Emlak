using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Entity.Concrete
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<Guid>
    {
    }
}
