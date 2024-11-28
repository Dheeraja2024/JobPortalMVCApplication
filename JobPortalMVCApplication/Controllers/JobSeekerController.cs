using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalMVCApplication.Models;

namespace JobPortalMVCApplication.Controllers
{
    public class JobSeekerController : Controller
    {
        JobSearchMvcEntities dbobj = new JobSearchMvcEntities();
        // GET: JobSeeker
        public ActionResult Jobseeker_PageLoad()
        {
            //dropdown list
            List<stclass> dropdownState = new List<stclass>
            {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
            };
            ViewBag.SelectedState = new SelectList(dropdownState, "sId", "sName");

            //checkbox list
            JobseekerRegistration clsobj = new JobseekerRegistration();
            clsobj.MyQualification = getQualificationData();
            return View(clsobj);
        }

        public List<Checkboxlist> getQualificationData()
        {
            List<Checkboxlist> qualification = new List<Checkboxlist>()
            {
                new Checkboxlist {Value="SSLC",Text="SSLC",IsChecked=true},
                 new Checkboxlist {Value="Plus Two",Text="Plus Two",IsChecked=false},
                  new Checkboxlist {Value="Btech",Text="Btech",IsChecked=false},
                   new Checkboxlist {Value="Mtech",Text="Mtech",IsChecked=false}
            };
            return qualification;
        }
        public ActionResult register_buttonClick(JobseekerRegistration clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if(ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Jobseeker Photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\Jobseeker Photos", fname);
                    clsobj.photo = fullpath;
                }

                List<stclass> dropdownState = new List<stclass>
                 {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
                 };
                ViewBag.SelectedState = new SelectList(dropdownState, "sId", "sName");

                int selectedId = Convert.ToInt32(form["ddlstates"]);
                stclass selectedItem = dropdownState.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;
                clsobj.sName = selectedItem.sName;

                var quid = string.Join(",", clsobj.SelectedQual);
                clsobj.qual = quid;
                clsobj.MyQualification = getQualificationData();

                var getmaxid = dbobj.sp_MaxLoginId().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }

                dbobj.sp_RegisterJobSeeker(regid, clsobj.name, Convert.ToInt32(clsobj.age ), clsobj.address, clsobj.email, clsobj.phone, clsobj.gender, clsobj.sName, clsobj.qual, clsobj.skill, clsobj.exp, clsobj.location, clsobj.photo);
                dbobj.sp_InsertLoginCredentials(regid, clsobj.username, clsobj.password, "User");
                clsobj.msg = "Successfully Inserted";
                 return View("Jobseeker_PageLoad", clsobj);
             // return RedirectToAction("Login_pageload", "Login");

            }
            else
            {
                List<stclass> stList = new List<stclass>
                 {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
                 };
                ViewBag.SelectedState = new SelectList(stList, "sId", "sName");

                clsobj.MyQualification = getQualificationData();

                return View("Jobseeker_PageLoad", clsobj);

            }
        }

        


    }
}