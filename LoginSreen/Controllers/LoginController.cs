using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginSreen.Models;



namespace LoginSreen.Controllers
{
    public class LoginController : Controller
    {
        DbMusteriEntities db = new DbMusteriEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(MusteriBilgileri p)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.MusteriBilgileri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SifreKontrol(MusteriBilgileri p)
        {

            var bilgi = db.MusteriBilgileri.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre==p.Sifre);

            if (bilgi!=null){

                return RedirectToAction("MusteriEkle",bilgi);
            }

            return RedirectToAction("Index");
        }
      
    }
}