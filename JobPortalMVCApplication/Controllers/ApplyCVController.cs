using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;

namespace JobPortalMVCApplication.Controllers
{
    public class ApplyCVController : Controller
    {
        // GET: ApplyCV
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        public ActionResult ApplyCV_Load(int cid,int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }

        public ActionResult Applyclick_Load(CVInsert clsobj,JobSearch obj,HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            { 
                if(file.ContentLength>0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Resume", fname);
                    clsobj.cv = fullpath;
                }
                dbobj.sp_applycv(Convert.ToInt32(Session["uid"].ToString()), Convert.ToInt32(TempData["id"]), clsobj.cv, DateTime.Now.ToString("yyyy-MM-dd"), "Applied");
                clsobj.appmsg = "APPLICATION SUBMITTED";
                return View("ApplyCV_Load",clsobj);
            }
            return View("ApplyCV_Load",clsobj);
        }
    }
}