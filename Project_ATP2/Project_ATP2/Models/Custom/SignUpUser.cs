using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_ATP2.Models.Custom
{
    public class SignUpUser
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Date of Birth required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage ="Phone NUmber required")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage ="Address Required")]
        public string Address { get; set; }
        //public HttpPostedFileBase Image { get; set; }
    }
}