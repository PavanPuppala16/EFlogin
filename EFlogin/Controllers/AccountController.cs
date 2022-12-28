using EFlogin.Dbmodel;
using EFlogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EFlogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        machinetextEntities ObjUserDBEntites = new machinetextEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            UserModel ObjUserModel = new UserModel();
            return View(ObjUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel ObjUserModel)
        {
            if (ModelState.IsValid)
            {
                User ObjUser = new Dbmodel.User();
                ObjUser.CreatedOn = DateTime.Now;
                ObjUser.UserId = ObjUserModel.UserId;
                ObjUser.Email = ObjUserModel.Email;
                ObjUser.FirstName = ObjUserModel.FirstName;
                ObjUser.LastName = ObjUserModel.LastName;
                ObjUser.Password = ObjUserModel.Password;

                ObjUserModel.SuccessMessage = " user sucessfully added";
                ObjUserModel = new UserModel();
                ObjUserDBEntites.Users.Add(ObjUser);
                ObjUserDBEntites.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel ObjLoginModel = new LoginModel();
            return View(ObjLoginModel);

        }
        [HttpPost]
        public ActionResult Login(LoginModel ObjLoginModel)
        {
            if(ModelState.IsValid)
            {
                if(ObjUserDBEntites.Users.Where(m=>m.Email == ObjLoginModel.Email&&m.Password==ObjLoginModel.Password).FirstOrDefault()==null)
                {
                    ModelState.AddModelError("error", "Email and password is not matching");
                    return View();
                }
                else
                {
                    Session["Email"]=ObjLoginModel.Email;
                    return  RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

    }

}