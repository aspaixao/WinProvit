using System;
using System.ComponentModel.DataAnnotations;

namespace WinProvit.DTO
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}