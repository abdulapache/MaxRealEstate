using System;
using System.Collections.Generic;

namespace MaxDataAccess.Entites
{
    public partial class AdminUser
    {
        public Guid Id { get; set; }
        public int AgentId { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
