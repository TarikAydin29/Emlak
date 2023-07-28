using Emlak.DAL.Abstract;
using Emlak.DAL.Concrete;
using Emlak.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService agentService;
        private readonly IPropertyService propertyService;

        public AgentController(IAgentService agentService,IPropertyService propertyService)
        {
            this.agentService = agentService;
            this.propertyService = propertyService;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = agentService.GetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var agent = agentService.GetById(id);
            if (agent == null)
            {
                return NotFound("Danışman bulunamadı");
            }
            if (agent.Properties != null)
            {

            }
            return Ok(agent);
        }


        [HttpPost]
        public IActionResult Add(Agent agent)
        {
            agentService.Add(agent);
            return CreatedAtAction("GetList", new { id = agent.AgentId }, agent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Agent agent)
        {
            var prop = agentService.GetById(id);
            if (prop == null)
            {
                return NotFound("Danışman bulunamadı");
            }
            agentService.Update(id, agent);
            return Ok($"{agent.AgentId} ID ye sahip danışman güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var agent = agentService.GetById(id);
            if (agent == null)
            {
                return NotFound("Danışman bulunamadı");
            }
            agentService.Delete(agent.AgentId);
            return Ok($"{agent.AgentId} ID ye sahip danışman silindi.");
        }


        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var agent = agentService.GetByName(name);
            if (agent == null)
            {
                return NotFound("Danışman bulunamadı");
            }
            if (agent.Properties != null)
            {

            }
            return Ok(agent);
        }
    }
}
