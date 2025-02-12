using System;
using System.Collections.Generic;

namespace MaxDataAccess.Entites
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedUser { get; set; }
        public string? PictureOne { get; set; }
        public string? PictureTwo { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
