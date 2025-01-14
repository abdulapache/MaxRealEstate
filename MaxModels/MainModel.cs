using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxModels
{
    public class MainModel
    {
        public List<AgentModel> Agents {  get; set; }
        public List<PropertyModel> property {  get; set; }
        public MainModel()
        {
            Agents = new List<AgentModel>();
            property = new List<PropertyModel>();
        }
    }
}
