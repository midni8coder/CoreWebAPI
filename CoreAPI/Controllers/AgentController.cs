using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AgentData agentData;
        public AgentController(IConfiguration Configuration) {
            _configuration = Configuration;
            agentData = new AgentData(_configuration);
        }
        string[] agents = {"agent 1", "agent 2", "agent 43", "agent 4", "agent 8", "agent 10" };
        [HttpGet("GetAllAgents")]
        public async Task<IActionResult> GetAllAgents()
        {
            var agents = await GetAgents();
            return Ok(agents);
        }

        private async Task<List<Agent>> GetAgents()
        {
            var agents =await  agentData.GetAllAgents();
            return agents;
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
