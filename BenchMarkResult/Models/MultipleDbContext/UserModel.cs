using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BenchMarkResult.Models.MultipleDbContext
{
    [Table("Users", Schema = "Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [StringLength(500)]
        public string AboutUser { get; set; }
    }
}
