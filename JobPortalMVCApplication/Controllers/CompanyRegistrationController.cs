using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;

namespace JobPortalMVCApplication.Controllers
{
    public class CompanyRegistrationController : Controller
    {
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        // GET: CompanyRegistration
        public ActionResult CompanyReg_Pageload()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}


        public ActionResult InsertCompany_Click( InsertCompany insertCompany, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength>0)
                {
                    var fname = Path.GetFileName(file.FileName);
                    var s=Server.MapPath("~/Company Photos/ ");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                     var fullpath=Path.Combine("~\\Company Photos\\" + fname);
                    insertCompany.photo = fullpath;
                }
                var maxLoginId=dbobj.sp_MaxLoginId().FirstOrDefault();
                int regId = 0;
                int maxId = Convert.ToInt32(maxLoginId);
                if (maxId==0)
                {
                    regId = 1;
                }
                else
                {
                    regId = maxId + 1;
                }
                dbobj.sp_RegisterCompany(regId, insertCompany.name, insertCompany.address, insertCompany.email, insertCompany.phone, insertCompany.website, insertCompany.photo);
                dbobj.sp_InsertLoginCredentials(regId, insertCompany.username, insertCompany.password, "Company");
                insertCompany.msg = "INSERTED SUCESSFULLY";
                return RedirectToAction("Login_pageload", "Login");
                //return View("InsertCompany_Click",insertCompany);
            }
            return View("Login");
        }
        
    }
}