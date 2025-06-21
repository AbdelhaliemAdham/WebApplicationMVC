using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.Models
{
    public class Villa
    {
        public int Id { get; set; }
        [Display(Name="Villa Name")]
        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price Per Unit")]
        [Range(1,10000)]
        public double Price { get; set; }
        [Range(1, 10)]
        public int Occupancy { get; set; }
        [Range(20,20000)]
        public int Sqfeet { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
