using System;
using System.ComponentModel.DataAnnotations;

namespace WinProvit.DTO
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
