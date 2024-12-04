using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalMVCApplication.Models
{
    public class CVInsert
    {
        public int jid { get; set; }
        public int uid { get; set; }
        public string cv { get; set; }
        public string applyDate { get; set; }
        public string status { get; set; }
        public string appmsg { get; set; }
    }
}