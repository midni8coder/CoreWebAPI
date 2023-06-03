using System.Text.Json.Serialization;

namespace Models
{
    [JsonSerializable(typeof(Agent))]
    public class Agent
    {
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        public string Email { get; set; }
        public int AgentId { get; set; }

    }
}