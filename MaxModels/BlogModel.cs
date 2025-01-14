using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxModels
{
    public class BlogModel
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
