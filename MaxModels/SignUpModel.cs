using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxModels
{
    public class SignUpModel
    {
        public Guid Id { get; set; }
        public int AgentId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
