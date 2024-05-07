using MVCPractice1.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast;

namespace MVCPractice1.Models
{
    public class FeedbackModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Feedback { get; set; }

        public int Srno { get; set; }
        public string Savereg(FeedbackModel model)
        {
            var msg = "Data Save Successfully!";

            MVCPractice1Entities Db = new MVCPractice1Entities();
            var form = Db.tblFeedbacks.Where(p => p.ID == model.ID).FirstOrDefault();
            if (model.ID == 0)
            {
                var regData = new tblFeedback()
                {
                    ID =model.ID,
                    Name = model.Name,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Feedback = model.Feedback,
                };
                Db.tblFeedbacks.Add(regData);
                Db.SaveChanges();
            }
            else
            {
                form.ID = model.ID;
                form.Name = model.Name;
                form.Email = model.Email;
                form.Mobile = model.Mobile;
                form.Feedback = model.Feedback;

                Db.SaveChanges();
                msg = "dataupdate!";
            }

            return msg;
        }


        public List<FeedbackModel> GetAddList()
        {
            MVCPractice1Entities Db = new MVCPractice1Entities();
            List<FeedbackModel> IstFeedback = new List<FeedbackModel>();
            var AddFeedbackList = Db.tblFeedbacks.ToList();
            int Srno = 1;
            if (AddFeedbackList != null)
            {
                foreach (var Feedback in AddFeedbackList)
                {
                    IstFeedback.Add(new FeedbackModel()
                    {
                        Srno = Srno,
                        ID = Feedback.ID,
                        Name = Feedback.Name,
                        Email = Feedback.Email,
                        Mobile = Feedback.Mobile,
                        Feedback = Feedback.Feedback,

                    });
                    Srno++;
                }
            }
            return IstFeedback;
        }
        public string DeleteFeedback(int ID)
        {

            var message = "delete successsful";
            MVCPractice1Entities Db = new MVCPractice1Entities();
            var data = Db.tblFeedbacks.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
                Db.tblFeedbacks.Remove(data);
                Db.SaveChanges();

            }
            return message;
        }
        public FeedbackModel GetUpdateFeed(int ID)
        {
            FeedbackModel model = new FeedbackModel();
            MVCPractice1Entities Db = new MVCPractice1Entities();
            var data = Db.tblFeedbacks.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
               
                Srno = Srno;
                model.ID = data.ID;
                model.Name = data.Name;
                model.Email = data.Email;
                model.Mobile = data.Mobile;
                model.Feedback = data.Feedback;
            };
            return model;
        }

    }
}