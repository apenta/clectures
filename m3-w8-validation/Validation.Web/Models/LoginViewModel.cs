using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ValidationSite.Web.Models
{
    //5. Create a LoginViewModel that has the properties that match the form
    public class LoginViewModel
    {
        //9. Add the Validation Rules to the Model

        [Required(ErrorMessage = "i need to know your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "whats your password, i wont share it")]
        public string Password { get; set; }
    }
}