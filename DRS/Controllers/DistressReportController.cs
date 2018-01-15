﻿using System;
using System.Web.Mvc;
using DRS.ControllerManagers.DistressReportControllerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class DistressReportController : Controller
    {
        private DistressReportControllerManager DistressReportControllerManager;

        public DistressReportController()
        {
            DistressReportControllerManager = new DistressReportControllerManager();
        }

        [Authorize(Roles ="Admin,User")]
        // GET: DistressReport
        public ActionResult Index(string SearchText)
        {
            try
            {
                return View(DistressReportControllerManager.getAllDistressReports(SearchText));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Index" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // GET: DistressReport/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();
                return View(DistressReportControllerManager.getDistressReport(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Details/int" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        //GET: DistressReport/CreateVessel
        public ActionResult CreateVessel(string SearchText)
        {
            vessel_owner_ref vessel_owner_ref = null;
            try
            {
                ViewBag.Registration = DistressReportControllerManager.getRegistrationSelectList();
                ViewBag.Districts = DistressReportControllerManager.getDistrictsSelectList();
                ViewBag.Applications = DistressReportControllerManager.getApplicationSelectList();

                if (SearchText != null && SearchText.Length != 0)
                {
                    vessel_owner_ref = DistressReportControllerManager.getVessel(SearchText);
                    if (vessel_owner_ref != null)
                    {
                        TempData["vessel_id_found"] = "Vessel Found!";
                        TempData["note"] = "Note : In case of distinct Owner data or update data please contact Colombo MCS Center, you cannot update below data";
                    }
                    else
                    {
                        TempData["vessel_id_not_found"] = "Vessel Not Found Please Enter Data To Submit!";
                    }
                }
                return View(vessel_owner_ref);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/CreateVessel" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        //POST: DistressReport/CreateVessel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVessel(vessel_owner_ref vessel_owner_ref)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int vessel_id = DistressReportControllerManager.createVessel(vessel_owner_ref);
                    if (vessel_id != 0)
                    {
                        return RedirectToAction("Create", new { id = vessel_id });
                    }
                }

                ViewBag.Registration = DistressReportControllerManager.getRegistrationSelectList();
                ViewBag.Districts = DistressReportControllerManager.getDistrictsSelectList();
                ViewBag.Applications = DistressReportControllerManager.getApplicationSelectList();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/CreateVessel" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // GET: DistressReport/Create
        public ActionResult Create(int id)
        {
            try
            {
                ViewBag.Distress = DistressReportControllerManager.getDistressSelectList();
                ViewBag.MCS = DistressReportControllerManager.getRadioStationsSelectList();
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View(new d_detail() { vessel_id = id, d_detail_action_taken = "No Action Taken", d_detail_remarks = "No Remarks", d_detail_no_of_crew = 0  });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Create" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // POST: DistressReport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(d_detail d_detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressReportControllerManager.saveDistressReport(d_detail);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Distress = DistressReportControllerManager.getDistressSelectList();
                ViewBag.MCS = DistressReportControllerManager.getRadioStationsSelectList();
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/CreateVessel" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // GET: DistressReport/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Distress = DistressReportControllerManager.getDistressSelectList();
                ViewBag.MCS = DistressReportControllerManager.getRadioStationsSelectList();
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View(DistressReportControllerManager.getDistressReport(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // POST: DistressReport/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, d_detail d_detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressReportControllerManager.updateDistressReport(id, d_detail);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Distress = DistressReportControllerManager.getDistressSelectList();
                ViewBag.MCS = DistressReportControllerManager.getRadioStationsSelectList();
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: DistressReport/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View(DistressReportControllerManager.getDistressReport(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: DistressReport/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, d_detail d_detail)
        {
            try
            {
                DistressReportControllerManager.deleteDistressReport(id, d_detail);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: DistressReport/Action/5
        public ActionResult Action(int id)
        {
            try
            {
                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View(DistressReportControllerManager.getDistressReport(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Action/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: DistressReport/Action/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Action(int id, d_detail d_detail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = DistressReportControllerManager.updateDistressReport(id, d_detail);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.LattitudeDirections = DistressReportControllerManager.getLattitudeDirectionsSelectList();
                ViewBag.LongitudeDirections = DistressReportControllerManager.getLongitudeDirectionsSelectList();

                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/Action/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: DistressReport/Report
        public ActionResult Report(int id)
        {
            try
            {
                return View(id);
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "GET/DistressReport/Report" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: DistressReport/Report
        [HttpPost]
        public ActionResult Report(int id, string report, string radioOfficer, string dutyOfficer)
        {
            try
            {
                ViewBag.report = report;
                ViewBag.radioOfficer = radioOfficer;
                ViewBag.dutyOfficer = dutyOfficer;
                return new Rotativa.ViewAsPdf("DistressReportPDF", DistressReportControllerManager.getDistressReport(id)) { FileName = "FAX MESSAGE.pdf" };
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { error = "POST/DistressReport/Report" });
            }
        }
    }
}