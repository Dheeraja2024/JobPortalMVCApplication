using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVCApplication.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }

        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { get; set; }
    }
    public class jsearch
    {
        public int job_id { get; set; }
        public int companyId { get; set; }
        public string skills { get; set; }
        public string experience { get; set; }
        public string location { get; set; }
        public string job_status { get; set; }
        public string last_Date { get; set; }
        public string posted_Date { get; set; }
        public string jobmsg { get; set; }

    }
}