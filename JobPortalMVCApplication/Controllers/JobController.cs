using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;

namespace JobPortalMVCApplication.Controllers
{
    public class JobController : Controller
    {
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        // GET: Job
        public ActionResult JobInsert_Pageload()
        {
            return View();
        }
        public ActionResult JobInsert_Click(InsertJobs clsobj)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(Session["uid"]);
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                dbobj.sp_InsertJobOpenings(userId, clsobj.jobTitle, clsobj.jobDesp, clsobj.jobSkills, clsobj.jobExp, clsobj.jobSalary, clsobj.jobLoc,  clsobj.jobStatus, clsobj.jobLastDate,Date);
              //  insert into tbl_Job values(@Cid, @jobTitle, @jobDes, @skill, @exp, @sal, @loc, @jobStatus, @lastDate, @postedDate);

                clsobj.jobMsg = "Successfully inserted";
                return View("JobInsert_Pageload", clsobj);
            }
            return View("JobInsert_Pageload", clsobj);
        }
    }
}