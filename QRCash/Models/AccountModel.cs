using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QRCash.Models
{
    public class SignUp
    {

        [StringLength(36)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string ConfirmPassword { get; set; }
    }

    public class SignIn
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
