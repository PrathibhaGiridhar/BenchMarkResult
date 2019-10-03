using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchMarkResult.Models.MultipleDbContext
{
    [Table("Products", Schema = "Product")]
    public class Products
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(600)]
        public string ImageUrl { get; set; }
    }
}
