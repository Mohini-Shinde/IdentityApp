﻿using System.ComponentModel.DataAnnotations;

namespace PlayerAPI.DTOs.Account
{
    public class ResetPasswordDto
    {   
        [Required]
        public string Token { get; set; }
        [Required]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage ="Invalid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength =6, ErrorMessage ="new Password must be atleast {2},  and maximum {1} characters")]
        public string NewPassword { get; set; }
    }
}
