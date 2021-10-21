using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        public int Role { get; set; }
    }
}
