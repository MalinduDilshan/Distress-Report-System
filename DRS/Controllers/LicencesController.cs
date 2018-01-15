using System;
using System.Web.Mvc;
using DRS.ControllerManagers.LicencesContollerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class LicencesController : Controller
    {
        private LicencesContollerManager LicencesContollerManager;

        public LicencesController()
        {
            LicencesContollerManager = new LicencesContollerManager();
        }

        [Authorize(Roles ="Admin,Officer")]
        // GET: Licences
        public ActionResult Index(string SearchText)
        {
            try
            {
                return View(LicencesContollerManager.getAllLicences(SearchText));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Index"});
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(LicencesContollerManager.getLicence(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Details/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/Create
        public ActionResult Create(string SearchText)
        {
            try
            {
                if (SearchText != null && SearchText.Length != 0)
                {
                    if (LicencesContollerManager.getVesselIdForRenewal(SearchText).vessel_id > 0)
                    {
                        TempData["vessel_id_found"] = "Vessel Found!";
                    }
                    else
                    {
                        TempData["vessel_id_not_found"] = "Vessel Not Found!";
                    }
                    return View(LicencesContollerManager.getVesselIdForRenewal(SearchText));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Create" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // POST: Licences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(licence licence)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (licence.vessel_id != 0)
                    {
                        int flag = LicencesContollerManager.saveLicence(licence);
                        if (flag == 1)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["licence_callsign"] = "This License Callsign or TRC File No already taken";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("","Warning! Vessel is not found");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/Create" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Licences/InvoiceState/5
        public ActionResult InvoiceState(string SearchText)  //Licence Callsign value will be asign as Pending
        {
            try
            {
                if (SearchText != null && SearchText.Length != 0)
                {
                    if (LicencesContollerManager.getVesselIdForInvoice(SearchText).vessel_id > 0)
                    {
                        TempData["vessel_id_found"] = "Vessel Found!";
                    }
                    else
                    {
                        TempData["vessel_id_not_found"] = "Vessel Not Found!";
                    }
                    return View(LicencesContollerManager.getVesselIdForInvoice(SearchText));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/InvoiceState/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //POST: Licences/InvoiceState/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvoiceState(licence licence)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (licence.vessel_id != 0)
                    {
                        int flag = LicencesContollerManager.InvoiceStateCreate(licence);
                        if (flag == 1)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["licence_trc_file_no"] = "This License TRC File No already taken";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Warning! Vessel is not found");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/InvoiceState/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //GET: Licences/Update/5
        public ActionResult Update(int id, int licence_id)
        {
           try
            {
                //pass licence id for get licence in update method
                return View(LicencesContollerManager.getLicence(licence_id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Update/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        //POST: Licences/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(licence licence, int licence_id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = LicencesContollerManager.updateExistLicence(licence, licence_id);   //return '2' as int status if execute successfully
                    if (flag == 2)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(LicencesContollerManager.getLicence(licence_id));
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/Update/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(LicencesContollerManager.getLicence(id));
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // POST: Licences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, licence licence)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = LicencesContollerManager.updateLicence(id, licence);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["callsign"] = "This License Callsign is already taken or you cannot save Callsign as Pending";
                    }
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(LicencesContollerManager.getLicence(id));
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // POST: Licences/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, licence licence)
        {
            try
            {
                LicencesContollerManager.deleteLicence(id, licence);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/Report
        public ActionResult Report()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/Report" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // POST: Licences/Report
        [HttpPost]
        public ActionResult Report(string example)
        {
            try
            {
                return RedirectToAction("GeneratePDF", new { vesselList = example });
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "POST/Licences/Report/string" });
            }
        }

        [Authorize(Roles = "Admin,Officer")]
        // GET: Licences/GeneratePDF
        public ActionResult GeneratePDF(string vesselList)
        {
           try
            {
                return new Rotativa.ViewAsPdf("GeneratePDF", LicencesContollerManager.getPDFVesselList(vesselList)) { FileName = "TRC.pdf" };
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Licences/GeneratePDF/string" });
            }
        }
    }
}
