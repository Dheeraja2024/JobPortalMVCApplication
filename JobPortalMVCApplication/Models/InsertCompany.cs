using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVCApplication.Models
{
    public class InsertCompany
    {
        //applied DataAnnotation validation for properties
        public int id { get; set; }

        [Required(ErrorMessage ="Enter  Name")]
        public string name { get; set; }


        [Required(ErrorMessage = "Enter  address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Enter Phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { get; set; }

       [EmailAddress(ErrorMessage ="Enter valid email address")]
        public string email { get; set; }

       [Required(ErrorMessage = "Website URL is required.")]
       [RegularExpression(@"^(https?:\/\/)?(www\.)?[a-zA-Z0-9-]+\.[a-zA-Z]{2,}(\/[^\s]*)?$", ErrorMessage = "Please enter a valid website URL.")]
        public string website { get; set; }

        //[Required(ErrorMessage = "Upload photo of company or company LOGO")]
        public string photo { get; set; }

       // [Required(ErrorMessage = "Enter  username")]
        public string username { get; set; }

       [Required(ErrorMessage = "Enter  password")]
        public string password { get; set; }

      [Compare("password",ErrorMessage ="PASSWORD MISMATCH")]
        public string cpassword { get; set; }

       [Required(ErrorMessage = "Enter  message")]
        public string msg { get; set; }

        

    }
}