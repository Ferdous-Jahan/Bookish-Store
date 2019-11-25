using Project_ATP2.Interfaces;
using Project_ATP2.Models;
using Project_ATP2.Models.Custom;
using Project_ATP2.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_ATP2.Controllers
{
    public class AccountController : Controller
    {
        LoginRepository repoLogin = new LoginRepository(new ProjectDBEntities());
        UserRepositoryJahan repoUser = new UserRepositoryJahan(new ProjectDBEntities());
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            bool isValid = repoLogin.VarifyLogin(Email, Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(Email, false);
                string userId = repoLogin.GetUserId(Email);
                if (userId != "0")
                {
                    Session["userId"] = userId;
                }
                var role = repoLogin.GetUserRole(Email);

                if (role[0] == "Customer")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (role[0] == "Salesman")
                {
                    return RedirectToAction("Index", "Salesman");
                }
                else if (role[0] == "ShippingManager")
                {
                    return RedirectToAction("Index", "ShippingManager");
                }
                else if (role[0] == "DeliveryMan")
                {
                    return RedirectToAction("Index", "DeliveryMan");
                }
                else if (role[0] == "Manager")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong! Please try again");
                    return View();
                }
                

                
            }

            ModelState.AddModelError("", "Email and Password is incorrect");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new SignUpUser());
        }

        [HttpPost]
        public ActionResult SignUp(SignUpUser su, HttpPostedFileBase Image)
        {
            string filenameUser;

            if (Image != null)
            {
                string filename = Path.GetFileNameWithoutExtension(Image.FileName);
                string extnss = Path.GetExtension(Image.FileName);
                filename = filename + DateTime.Now.ToString("yymmddfff") + extnss;
                filenameUser = filename;
                filename = Path.Combine(Server.MapPath("~/Images/ProfilePicture/"), filename);
                Image.SaveAs(filename);
            }
            else
            {
                filenameUser = "default.jpg";
            }
            User u = new User();
            u.Name = su.Name;
            u.Email = su.Email;
            u.Address = su.Address;
            u.DOB = su.DOB.ToString();
            u.PhoneNumber = su.PhoneNumber.ToString();
            u.Role_Id = 1;
            u.Image = filenameUser;
            u.AddedDate = DateTime.Now;
            u.ModifiedDate = DateTime.Now;
            repoUser.Insert(u);
            repoUser.SaveChanges();

            Login l = new Login();
            l.Email = su.Email;
            l.Pass = su.Password;
            l.Role_Id = 1;
            l.Status = "APPROVED";
            u = repoUser.GetByEmail(su.Email);
            if (u != null)
                l.User_Id = u.Id;

            repoLogin.Insert(l);
            repoLogin.SaveChanges();

            Session["UserEmail"] = su.Email;
            //return Content(su.Password);
            return RedirectToAction("Index", "Home");
        }


        //    // GET: Account/Details/5
        //    public ActionResult Details(int id)
        //    {
        //        return View();
        //    }

        //    // GET: Account/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Account/Create
        //    [HttpPost]
        //    public ActionResult Create(FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add insert logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Account/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Account/Edit/5
        //    [HttpPost]
        //    public ActionResult Edit(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add update logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Account/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Account/Delete/5
        //    [HttpPost]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
