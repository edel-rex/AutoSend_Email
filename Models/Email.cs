using System;
using System.ComponentModel.DataAnnotations;

namespace AutoSend_Email.Models
{
    public class Email
    {
        [Required, EmailAddress]
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;

    }
}
