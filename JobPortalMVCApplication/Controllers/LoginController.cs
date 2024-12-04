using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;


namespace JobPortalMVCApplication.Controllers
{
    public class LoginController : Controller
    {
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        // GET: Login
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult login_click(LoginCls loginCls)
        {
            if (ModelState.IsValid)
            {
                var getId = dbobj.sp_CountLoginId(loginCls.username, loginCls.password).FirstOrDefault();
                if (Convert.ToInt32(getId) == 1)
                {
                    var getRegId = dbobj.sp_GetLoginId(loginCls.username, loginCls.password).FirstOrDefault();
                    Session["uid"] = getRegId;
                    string userType = dbobj.sp_LoginType(loginCls.username, loginCls.password).FirstOrDefault();
                    if (userType == "Company")
                    {
                        return RedirectToAction("AdminHome");
                    }
                    else if (userType == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    loginCls.msg = "INVALID USERNAME OR PASSWORD";
                    return View("Login_pageload", loginCls);
                }
            }
            return View("Login_pageload", loginCls);
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            var job = dbobj.tbl_Job.ToList();
            return View(job);
            //  var jobs=dbobj.sp_fetchAllJobDetails();
           // return View(jobs);
        }
    }
}