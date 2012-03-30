using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TankMap.DataAccess;
using System.Web.Script.Serialization;
using TankMap.Models;

namespace TankMap.Controllers
{
    public class MapController : Controller
    {
        private IRepository<Tank> _repo;

        public MapController(IRepository<Tank> repo)
        {
            _repo = repo;
        }

        //
        // GET: /Map/

        public ActionResult Index()
        {
            var dataContext = new SpreadSheetLoad();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var output = serializer.Serialize(_repo.All());
            ViewBag.tanks = output;
            return View();
        }
    }
}
