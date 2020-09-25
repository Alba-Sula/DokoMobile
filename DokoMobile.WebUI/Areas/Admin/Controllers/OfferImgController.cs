using DokoMobile.Domain.Abstract;
using DokoMobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DokoMobile.WebUI.Areas.Admin.Controllers
{
    public class OfferImgController : Controller
    {
        private IRepository repository;
        public OfferImgController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {

            return View(repository.OfferImgs);
        }

        public ActionResult Create()
        {
            return View("Edit", new OfferImg());
        }

        public ActionResult Edit(int id)
        {
            var offerImg = repository.OfferImgs.Where(o => o.OfferImgID == id).FirstOrDefault();
            return View(offerImg);
        }

        [HttpPost]
        public ActionResult Edit(OfferImg offerImg)
        {
            string imgToSave = null;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extention = Path.GetExtension(file.FileName);
                fileName = "dokoMobile-" + fileName + extention;
                imgToSave = "/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(fileName);
            }
            offerImg.ImgPath = imgToSave;
            string imgToDelete = repository.SaveOfferImgs(offerImg);
            if (imgToDelete != null)
            {
                if (System.IO.File.Exists(imgToDelete))
                {
                    System.IO.File.Delete(imgToDelete);
                }

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            OfferImg offerImgToDelete = repository.DeleteOfferImg(id);
            if (offerImgToDelete != null)
            {
                if (System.IO.File.Exists(offerImgToDelete.ImgPath))
                {
                    System.IO.File.Delete(offerImgToDelete.ImgPath);
                }
                TempData["message"] = "The offer got deleted";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}