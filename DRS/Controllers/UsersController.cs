using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.ControllerManagers.UsersControllerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class UsersController : Controller
    {

        private UsersControllerManager UsersControllerManager;

        public UsersController()
        {
            UsersControllerManager = new UsersControllerManager();
        }

        [Authorize(Roles = "Admin")]
        // GET: Users
        public ActionResult Index()
        {
            try
            {
                return View(UsersControllerManager.getAllUsers());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Users/Index" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(UsersControllerManager.getUser(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Users/Details/int" });
            }
        }

        //This method logic moved to the Register method in AccountsController
        [Authorize(Roles = "Admin")]
        // GET: Users/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.mcs = UsersControllerManager.getRadioStationsSelectList();
                return View(new user() { user_username=HttpContext.User.Identity.Name});
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Users/Create" });
            }
        }

        //This method logic moved to the Register method in AccountsController
        [Authorize(Roles = "Admin")]
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = UsersControllerManager.saveUser(user);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["user_username"] = "This MCS Center is already have a user";
                        ViewBag.mcs = UsersControllerManager.getRadioStationsSelectList();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Users/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.mcs = UsersControllerManager.getRadioStationsSelectList();
                return View(UsersControllerManager.getUser(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Users/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = UsersControllerManager.updateUser(id, user);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.mcs = UsersControllerManager.getRadioStationsSelectList();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Users/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(UsersControllerManager.getUser(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Users/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = UsersControllerManager.deleteUser(id, user);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Users/Delete/int" });
            }
        }
    }
}