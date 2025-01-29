using System;
using System.Collections.Generic;

namespace MaxDataAccess.Entites
{
    public partial class UserQuery
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Purpose { get; set; }
        public string? Property { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
