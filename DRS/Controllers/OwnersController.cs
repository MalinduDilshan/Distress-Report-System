using System;
using System.Web.Mvc;
using DRS.ControllerManagers.OwnersControllerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class OwnersController : Controller
    {
        private OwnersControllerManager OwnersControllerManager;

        public OwnersController()
        {
            OwnersControllerManager = new OwnersControllerManager();
        }

        // GET: Owners
        public ActionResult Index(string SearchType, string SearchText)
        {
            try
            {
                ViewBag.SearchOwnerType = OwnersControllerManager.getSearchOwnerTypeSelectList();
                if (SearchType != null && SearchType.Length != 0)
                {
                    return View(OwnersControllerManager.getAllOwners(SearchType, SearchText));
                }
                else
                {
                    return View(OwnersControllerManager.getOwnersICollection());
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/Index" });
            }
        }

        // GTE: Owners/Details/1
        public ActionResult Details(int id)
        {
            try
            {
                return View(OwnersControllerManager.getOwner(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/Details/int" });
            }
        }

        // GTE: Owners/Vessels/5
        public ActionResult Vessels(int id)
        {
            try
            {
                return View(OwnersControllerManager.getAllVessels(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/Vessels/int" });
            }
        }

        // GET: Owners/MultipleVessels/5
        public ActionResult MultipleVessels(int id)
        {
            try
            {
                ViewBag.Registration = OwnersControllerManager.getRegistrationSelectList();
                ViewBag.Districts = OwnersControllerManager.getDistrictsSelectList();
                ViewBag.Applications = OwnersControllerManager.getApplicationSelectList();
                return View(OwnersControllerManager.getOwnerOnly(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/MultipleVessels/int" });
            }
        }

        // POST: Owners/MultipleVessels
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MultipleVessels(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int status = OwnersControllerManager.saveMultipleVessel(vessel_owner_ref);
                    if (status == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["vessel_no"] = "This Vessel is already assign for this owner";
                        ViewBag.Registration = OwnersControllerManager.getRegistrationSelectList();
                        ViewBag.Districts = OwnersControllerManager.getDistrictsSelectList();
                        ViewBag.Applications = OwnersControllerManager.getApplicationSelectList();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Owners/MultipleVessels" });
            }
        }

        // GET: Owners/Edit/1
        public ActionResult Edit(int id)
        {
            try
            {
                return View(OwnersControllerManager.getOwner(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/Edit/int" });
            }
        }

        // POST: Owners/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, owner owner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int status = OwnersControllerManager.updateOwner(id, owner);
                    if (status == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Owners/Edit/int" });
            }
        }

        // GTE: Owners/Delete/1
        public ActionResult Delete(int id)
        {
            try
            {
                return View(OwnersControllerManager.getOwner(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Owners/Delete/int" });
            }
        }

        // POST: Owners/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int status = OwnersControllerManager.deleteOwner(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Owners/DeletePost/int" });
            }
        }
    }
}