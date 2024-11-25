using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVCApplication.Models
{
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    public class Checkboxlist
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class JobseekerRegistration
    {
        public int sId { set; get; }
        public string sName { set; get; }

        public List<Checkboxlist> MyQualification { get; set; }
        public string[] SelectedQual { set; get; }
        public int id { get; set; }

        [Required(ErrorMessage = "Enter name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter address")]
        public string address { get; set; }

       [Range(18,50,ErrorMessage = "Enter age")]
        public string age { get; set; }

       [EmailAddress(ErrorMessage = "Enter valid email")]
        public string email { get; set; }


        [Required(ErrorMessage = "Enter Phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string phone { get; set; }

      
        public string qual { get; set; }

      //[Required(ErrorMessage = "Enter gender")]
        public string gender { get; set; }

       //[Required(ErrorMessage = "Enter state")]
       public string state { get; set; }

       [Required(ErrorMessage = "Enter skill")]
        public string skill { get; set; }

       [Required(ErrorMessage = "Enter exp")]
        public string exp { get; set; }

       [Required(ErrorMessage = "Enter location")]
        public string location { get; set; }

      //[Required(ErrorMessage = "Upload photo")]
        public string photo { get; set; }

       [Required(ErrorMessage = "Enter username")]
        public string username { get; set; }

       [Required(ErrorMessage = "Enter password")]
        public string password { get; set; }

        [Compare("password",ErrorMessage = "PASSWORD MISMATCH")]
        public string cpassword { get; set; }

        public string msg { get; set; }

    }
}