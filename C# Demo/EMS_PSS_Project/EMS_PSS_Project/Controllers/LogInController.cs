/*
 * File Name : EMS_PersonController.cs
 * 
 * Project : INFO2030 - EMS PSS Project
 * 
 * Programmer : Lingchen Meng (Walter) / 6818678 
 *              Xuan Zhang / 5283460 
 *              Geun Young Gil / 6944920 
 *              Markus Rankin / 3379187
 *              
 * First Verson : 2016-04-21
 * 
 * Description : The file is used to control Login Action.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMS_PSS_Project.Models;
using EMS_PSS_Project.DAL;


namespace EMS_PSS_Project.Controllers
{
    public class LogInController : Controller
    {
        //// GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }


        /// <summary>
        /// This function is used to log in to main page.
        /// </summary>
        /// <param name="u"> this user infro. </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(EMS_User u)
        {
            // this action is for handle post.
            if (ModelState.IsValid) // this is check validity.
            {
                using (EMS_PSS_DBContext dt = new EMS_PSS_DBContext())
                {
                    // check database to see if this user in database.
                    var v = dt.EMS_Users.Where(s => s.User_Name.Equals(u.User_Name) && s.PassWord.Equals(u.PassWord)).FirstOrDefault();
                    // if user is exist.
                    if (v != null)
                    {
                        // set info to session.
                        Session["LogedUserID"] = v.User_ID.ToString();
                        Session["LogedUserName"] = v.User_Name.ToString();
                        Session["LogedSecurityLevel"] = v.SecurityLevel_ID.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }

            // return view.
            return View(u);
        }





        /// <summary>
        /// This function is used to display page when user login.
        /// </summary>
        /// <returns></returns>
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }





        /// <summary>
        /// This function is used to display create log in page.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateLogIn()
        {
            return View("CreateLogin");
        }
    }
}