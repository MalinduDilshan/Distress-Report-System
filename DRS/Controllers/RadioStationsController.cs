using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRS.ControllerManagers.RadioStationControllerManager;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class RadioStationsController : Controller
    {
        private RadioStationsControllerManager RadioStationsControllerManager;

        public RadioStationsController()
        {
            RadioStationsControllerManager = new RadioStationsControllerManager();
        }

        [Authorize(Roles = "Admin,User")]
        // GET: RadioStations
        public ActionResult Index()
        {
            try
            {
                return View(RadioStationsControllerManager.getAllRadioStations());
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStations/Index" });
            }
        }

        [Authorize(Roles = "Admin,User")]
        // GET: RadioStations/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStations/Details/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStations/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(radio_station radio_station)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int flag = RadioStationsControllerManager.saveRadioStation(radio_station);
                    if (flag == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["mcs_callsign"] = "This MCS Center Callsign is already taken";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStations/Create" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, radio_station radio_station)
        {
            try
            {
                int flag = RadioStationsControllerManager.updateRadioStation(id, radio_station);
                if (flag == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStations/Edit/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: RadioStations/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(RadioStationsControllerManager.getRadioStation(id));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "GET/RadioStations/Delete/int" });
            }
        }

        [Authorize(Roles = "Admin")]
        // POST: RadioStations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, radio_station radio_station)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RadioStationsControllerManager.deleteRadioStation(id, radio_station);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { error = "POST/RadioStations/Delete/int" });
            }
        }
    }
}
