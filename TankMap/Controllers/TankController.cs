using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankMap.DataAccess;
using TankMap.Models;

namespace TankMap.Controllers
{
    public class TankController : Controller
    {
        private IRepository<Tank> _repo;

        public TankController(IRepository<Tank> repo)
        {
            _repo = repo;
        }

        //
        // GET: /Tank/

        public ActionResult Index()
        {
            return View(_repo.All());
        }

        //
        // GET: /Tank/Details/5

        public ActionResult Details(int id)
        {
            var tank = _repo.SingleOrDefault(c => c.ID == id);
            return View(tank);
        }

        //
        // GET: /Tank/Create

        public ActionResult Create()
        {
            var tank = new Tank();
            return View(tank);
        }

        //
        // POST: /Tank/Create

        [HttpPost]
        public ActionResult Create(Tank tank)
        {
            try
            {
                _repo.Save(tank);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tank/Edit/5

        public ActionResult Edit(int id)
        {
            var tank = _repo.SingleOrDefault(c => c.ID == id);
            return View(tank);
        }

        //
        // POST: /Tank/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var tank = _repo.SingleOrDefault(t => t.ID == id);

                TryUpdateModel(tank);

                _repo.Save(tank);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tank/Delete/5

        public ActionResult Delete(int id)
        {
            var tank = _repo.SingleOrDefault(t => t.ID == id);
            _repo.Delete(tank);
            return View();
        }

        //
        // POST: /Tank/Delete/5

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


        //
        // GET: /Tank/Load
        public ActionResult Load()
        {
            return View();
        }


        //
        // POST: /Tank/Load
        [HttpPost]
        public ActionResult Load(HttpPostedFileBase file)
        {
            var dataContext = new SpreadSheetLoad();
            dataContext.LoadTanks(_repo, file);

            return View();
        }
    }
}
