using Business.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProductStock.Controllers
{
    public class StockController : Controller
    {
        StockManager _rm = new StockManager();

        // GET: RawMaterials
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StockListAdd()
        {
            var data = _rm.StockListAdd(); 
            return Json(data, JsonRequestBehavior.AllowGet);//http get'de json işlemi yapıldığında JsonRequestBehavior işlemi yapılması gerekiyor yoksa proje hata veriyor. çünkü http get işlemi güvenli olmadığı için bilgilerimiz direk görülebilmektedir. son işlemini yapma sebebimizde datatype json olduğu için
        }

        [HttpGet]
        public ActionResult StockList()
        {
            var data = _rm.StockList(); 
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            var data = _rm.ProductList();
            return Json(data, JsonRequestBehavior.AllowGet); 
        }
    }
}