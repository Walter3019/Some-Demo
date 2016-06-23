/*
 * File Name : UserCOntroller.cs
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
 * Description : The file is used to control User in database include (display, edit, create, delete).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using EMS_PSS_Project.Models;
using EMS_PSS_Project.DAL;

namespace EMS_PSS_Project.Controllers
{
    public class UserController : Controller
    {
        // instance a context.
        EMS_PSS_DBContext db = new EMS_PSS_DBContext();



        /// <summary>
        /// This function is used to display all users in database, and also can sort database and find specific user.
        /// </summary>
        /// <param name="sortOrder"> sort order ASC DESC </param>
        /// <param name="searchString"> Searching string. </param>
        /// <param name="currentFilter"> curren Filter.</param>
        /// <param name="page"> the number of page.</param>
        /// <returns></returns>
        public ActionResult Index(String sortOrder, String searchString, String currentFilter, int? page)
        {
            //page list
            ViewBag.CurrentSort = sortOrder;

            // check searching string to see whether is empty.
            if (searchString != null)
            {
                page = 1;
            }
            else // otherwise.
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // sorting data
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DatSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var users = from s in db.EMS_Users select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Last_Name.Contains(searchString) || s.First_Name.Contains(searchString));
            }

            // sort order.
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.First_Name);
                    break;
                case "":
                    users = users.OrderBy(s => s.SecurityLevel.ScurityDescription);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(s => s.SecurityLevel.ScurityDescription);
                    break;
                default:
                    users = users.OrderBy(s => s.Last_Name);
                    break;
            }

            // page size
            int PageSize = 3;
            int PageNumber = (page ?? 1);

            // return view page.
            return View("SearchUesr", users.ToPagedList(PageNumber, PageSize));
        }






        /// <summary>
        /// This function is used to create a user.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateUser()
        {

            // replace SecurityLevel_ID to ScurityDescription.
            ViewBag.SecurityLevel_ID = new SelectList(db.EMS_SecurityLevel, "SecurityLevel_ID", "ScurityDescription");
            // return result.
            return View("Index");
        }





        /// <summary>
        /// This function is used to create a user when page is post back.
        /// </summary>
        /// <param name="u"> the info of this user.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateUser(EMS_User u)
        {
            // replace SecurityLevel_ID to ScurityDescription.
            ViewBag.SecurityLevel_ID = new SelectList(db.EMS_SecurityLevel, "SecurityLevel_ID", "ScurityDescription");

            // is model state.
            if (ModelState.IsValid)
            {
                // add new user into database.
                db.EMS_Users.Add(u);
                // save change.
                db.SaveChanges();
                return RedirectToAction("LogIn", "LogIn");
            }

            // return view layer.
            return View("Index");
        }





        /// <summary>
        /// This function is used to seaching a user in database.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchUser()
        {
            ViewBag.SecurityLevel_ID = new SelectList(db.EMS_SecurityLevel, "SecurityLevel_ID", "ScurityDescription");

            var Users = db.EMS_Users;
            return View("SearchUser", Users.ToList());
        }





    }
}