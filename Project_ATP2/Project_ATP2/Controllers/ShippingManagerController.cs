using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_ATP2.Controllers
{
    public class ShippingManagerController : Controller
    {

        [Authorize(Roles = "ShippingManager")]
        // GET: ShippingManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShippingManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShippingManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShippingManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShippingManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShippingManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
