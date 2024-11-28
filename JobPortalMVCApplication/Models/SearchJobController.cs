using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobPortalMVCApplication.Models
{
    public class SearchJobController : Controller
    {
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        // GET: SearchJob
        public ActionResult searchjob_pageload()
        {
            var job = dbobj.tbl_Job.ToList();
            return View(job);
        }

        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if(!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and Experience like '%" + clsobj.insertse.experience + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and Skills like '%" + clsobj.insertse.skills + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.location))
            {
                qry += " and Loction like '%" + clsobj.insertse.location + "'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.posted_Date))
            {
                qry += " and PostedDate like '%" + clsobj.insertse.posted_Date + "'";
            }
            return View("searchjob_pageload",getdata1(clsobj,qry));
        }

        private JobSearch getdata1(JobSearch clsobj,string qry)
        {
            using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[sp_Jobsearches]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while(dr.Read())
                {
                    var jobcls = new jsearch();
                   jobcls.companyId= Convert.ToInt32( dr["fk_CompanyId"].ToString());
                    jobcls.skills = dr["Skills"].ToString();
                    jobcls.experience = dr["Experience"].ToString();
                    jobcls.job_status = dr["JobStatus"].ToString();
                    jobcls.last_Date = dr["ApplyLastDate"].ToString();

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}