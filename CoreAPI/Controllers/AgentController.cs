using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        string[] agents = {"agent 1", "agent 2", "agent 43", "agent 4", "agent 8", "agent 10" };
        [HttpGet("GetAllAgents")]
        public IActionResult GetAllAgents()
        {
            return Ok(agents);
        }
        [HttpGet("Test")]
        public IActionResult AnotherGet()
        {
            return Ok(agents);
        }
        [HttpGet("{id}")]
        public IActionResult GetAgentById(int id)
        {
            return Ok(agents[id]);
        }
    }
}
