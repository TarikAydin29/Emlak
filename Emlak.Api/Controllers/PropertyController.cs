using Emlak.DAL.Abstract;
using Emlak.DAL.Concrete;
using Emlak.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Emlak.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
   
        [HttpGet]
        public IActionResult GetList()
        {
            var values =  propertyService.GetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var prop = propertyService.GetById(id);
            if (prop == null)
            {
                return NotFound("Mülk bulunamadı");
            }
            return Ok(prop);
        }


        [HttpPost]
        public IActionResult Add(Property property)
        {
            propertyService.Add(property);
            return CreatedAtAction("GetList", new { id = property.PropertyID }, property);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id,Property property)
        {
            var prop = propertyService.GetById(id);
            if (prop == null)
            {
                return NotFound("Mülk bulunamadı");
            }
            propertyService.Update(id, property);
            return Ok($"{property.PropertyID} ID ye sahip mülk güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var prop = propertyService.GetById(id);
            if (prop == null)
            {
                return NotFound("Mülk bulunamadı");
            }
            propertyService.Delete(prop.PropertyID);
            return Ok($"{prop.PropertyID} ID ye sahip mülk silindi.");
        }
    }
}
