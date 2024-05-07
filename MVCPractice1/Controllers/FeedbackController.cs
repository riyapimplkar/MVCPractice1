using MVCPractice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice1.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult FeedIndex()
        {
            return View();
        }
        public ActionResult DetailsIndex(int ID)
        {
            ViewBag.ID = ID;
            Session["ID"] = ID;
            return View();
        }
        public ActionResult Savereg(FeedbackModel model)

        {
            try
            {
                return Json(new { Message = (new FeedbackModel().Savereg(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAddList()
        {
            try
            {
                return Json(new { model = (new FeedbackModel().GetAddList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult DeleteFeedback(int ID)
        {
            try
            {
                return Json(new { model = new FeedbackModel().DeleteFeedback(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetUpdateFeed()
        {
            int ID = 0;
            if (Session["ID"] != null) { 
             ID = (int)Session["ID"];
            }
            try
            {
                return Json(new { model = new FeedbackModel().GetUpdateFeed(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}