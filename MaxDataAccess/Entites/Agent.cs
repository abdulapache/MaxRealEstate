using System;
using System.Collections.Generic;

namespace MaxDataAccess.Entites
{
    public partial class Agent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Profile { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
