﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortalMVCApplication.Models
{
    public class InsertJobs
    {
        public int cId { set; get; }
        [Required(ErrorMessage = "Enter Job Title")]
        public string jobTitle { set; get; }
        [Required(ErrorMessage = "Enter Job Description")]
        public string jobDesp { set; get; }
        [Required(ErrorMessage = "Enter Job Skills")]
        public string jobSkills { set; get; }
        [Required(ErrorMessage = "Enter required Job experience")]
        public string jobExp { set; get; }
        [Required(ErrorMessage = "Enter Job Salary range")]
        public string jobSalary { set; get; }
        [Required(ErrorMessage = "Enter Job location")]
        public string jobLoc { set; get; }
        [Required(ErrorMessage = "Enter Last date to Apply")]
        public string jobLastDate { set; get; }

        [Required(ErrorMessage = "Enter Job status")]
        public string jobStatus { set; get; }
        
        public string jobPostedDate { set; get; }
        public string jobMsg { set; get; }
        //insert into tbl_Job values(@Cid, @jobTitle, @jobDes, @skill, @exp, @sal, @loc, @jobStatus, @lastDate, @postedDate);

    }
}