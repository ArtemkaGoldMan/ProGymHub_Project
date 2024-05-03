using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]

        public string? FullName { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

    }
}
