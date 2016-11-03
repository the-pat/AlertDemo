using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlertDemo.Models
{
    public class SmsModel
    {
        [Display(Name = "Message Body")]
        [Required(ErrorMessage = "Please enter the message body")]
        public string Body { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter the phone number of the recipient")]
        public string To { get; set; }
    }
}