using System;
using System.Collections.Generic;

namespace MaxDataAccess.Entites
{
    public partial class Property
    {
        public int Id { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyType { get; set; }
        public string? CommercialType { get; set; }
        public string? ResidentType { get; set; }
        public string? Purpose { get; set; }
        public string? SqFt { get; set; }
        public int? TotalBedroom { get; set; }
        public int? TotalBath { get; set; }
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }
        public string? Pic3 { get; set; }
        public string? Price { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Address { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerAddress { get; set; }
        public string? OwnerPhoneNumber { get; set; }
        public int? AgentId { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
