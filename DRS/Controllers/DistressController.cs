using System;
using System.Web.Mvc;
using DRS.ControllerManagers.DistressControllerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class DistressController : Controller
    {
        private DistressControllerManager DistressControllerManager;

        public DistressController()
        {
            DistressControllerManager = new DistressControllerManager();
        }

        [Authorize(Roles = "Admin")]
        // GET: Distress
        public ActionResult Index()
        {
            try
            {
                return View(DistressControllerManager.getAllDistress());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Distress/Index" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Distress/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(DistressControllerManager.getDistress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Distress/Details/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Distress/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Distress/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Distress/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(distress distress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressControllerManager.saveDistress(distress);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Distress/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Distress/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(DistressControllerManager.getDistress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Distress/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Distress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, distress distress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressControllerManager.updateDistress(id, distress);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Distress/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Distress/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(DistressControllerManager.getDistress(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Distress/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: Distress/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, distress distress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressControllerManager.deleteDistress(id, distress);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Distress/Delete/int" });
            }
        }
    }
}