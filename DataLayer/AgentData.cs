using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace DataLayer
{
    public class AgentData
    {
        private readonly IConfiguration _configuration;
        public AgentData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Agent>> GetAllAgents()
        {
            string constr = _configuration.GetConnectionString("LocalDB");
            List<Agent> agents = new List<Agent>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Agent";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                    {
                        while (sdr.Read())
                        {
                            agents.Add(new Agent()
                            {
                                AgentName = Convert.ToString(sdr["AgentName"]),
                                AgentCode = Convert.ToString(sdr["AgentCode"]),
                                Email = Convert.ToString(sdr["Email"]),
                                AgentId = Convert.ToInt32(sdr["AgentId"])
                            });
                        }
                    }
                    con.Close();
                }
            }
            return agents;
        }
        //public async Task<Agent> SaveAgent(Agent agent)
        //{
        //    string constr = _configuration.GetConnectionString("LocalDB");
        //    List<Agent> agents = new List<Agent>();
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = "SELECT * FROM Agent";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
        //            {
        //                while (sdr.Read())
        //                {
        //                    agents.Add(new Agent()
        //                    {
        //                        AgentName = Convert.ToString(sdr["AgentName"]),
        //                        AgentCode = Convert.ToString(sdr["AgentCode"]),
        //                        Email = Convert.ToString(sdr["Email"]),
        //                        AgentId = Convert.ToInt32(sdr["AgentId"])
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //    return agents;
        //}
    }
}