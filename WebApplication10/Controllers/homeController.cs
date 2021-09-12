using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class homeController : Controller
    {
        // GET: home

        public ActionResult hitsmain()
        {
            return View();
        }
        public ActionResult popmain()
        {
            ViewBag.comm = sql.Exec("select * from comment");
            return View();
        }

        [HttpPost]
        public ActionResult popmain(string fname, string lname, string comment)
        {
            sql.Exec($"insert into comment values (N'{fname}', N'{lname}', N'{comment}')");
            return RedirectToAction("popmain");
        }

        public ActionResult community()
        {
            return View();
        }
        [HttpPost]
        public ActionResult community(string email, string ad, string trackname, string myfile, string message)
        {
            sql.Exec($"insert into comm1 values (N'{ad}', N'{trackname}', N'{myfile}', N'{email}', N'{message}')");
            return RedirectToAction("community");
        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(string email, string ad, string password)
        {
            sql.Exec($"insert into users values (N'{ad}', N'{password}', N'{email}')");
            return RedirectToAction("signin");
        }
        public ActionResult signin()
        {
            return View();
        }
        public ActionResult signinmain(string lg_username, string lg_password)
        {

            DataTable dt = new DataTable();
            dt = sql.Exec($"select username, userpass from users where (username= N'{lg_username}' and userpass=N'{lg_password}') ");
            var un = dt.Rows[0][0].ToString();
            var up = dt.Rows[0][1].ToString();

            if (un == lg_username && up == lg_password)
            {
                HttpCookie cookie = new HttpCookie("users");
                cookie.Values.Add("islogin", "true");
                Response.Cookies.Add(cookie);
                return RedirectToAction("indexmain");
            }
            else
            {
                return View();
            }
        }

        public ActionResult indexmain()
        {
            return View();
        }

        public ActionResult cooperation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cooperation(string email, string ad, string coomessage)
        {
            sql.Exec($"insert into coop values (N'{ad}',N'{email}', N'{coomessage}')");
            return RedirectToAction("cooperation");
        }

        public ActionResult logout()
        {
            HttpCookie cookie = new HttpCookie("users");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            return RedirectToAction("indexmain");
        }
        public ActionResult oldsch()
        {
            return View();
        }

        public ActionResult sale()
        {
            var cookie = Request.Cookies["users"];
            if (cookie == null)
            {
                return RedirectToAction("signin");
            }
            else
            {
                return View();
            }

        }
        public ActionResult salepaged()
        {
            var cookie = Request.Cookies["users"];
            if (cookie == null)
            {
                return RedirectToAction("signin");
            }
            else
            {

                return View();
            }

        }
        public ActionResult saladdx()
        {
            return View();
        }
        public ActionResult traps()
        {
            return View();
        }
    }
}