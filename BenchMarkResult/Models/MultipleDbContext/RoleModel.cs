using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BenchMarkResult.Models.MultipleDbContext
{
    [Table("Role", Schema = "Users")]
    public class RoleModel
    {
        [Key, MaxLength(60)]
        public string Key { get; set; }

        [Required, MaxLength(250)]
        public string Description { get; set; }
    }
}
