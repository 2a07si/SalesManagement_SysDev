using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class LoginHistoryLog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoginID { get; set; }

        [Required]
        [MaxLength(100)]
        public string LoginEmName { get; set; }

        public DateTime LoginDateTime { get; set; }

        public bool IsSuccessful { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
