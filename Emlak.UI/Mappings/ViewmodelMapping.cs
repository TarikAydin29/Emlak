using AutoMapper;
using Emlak.Entity.Concrete;
using Emlak.UI.Models.PropertyVMs;

namespace Emlak.UI.Mappings
{
    public class ViewmodelMapping:Profile
    {
        public ViewmodelMapping()
        {
            CreateMap<CreatePropertyVM, Property>().ReverseMap();
        }
    }
}
