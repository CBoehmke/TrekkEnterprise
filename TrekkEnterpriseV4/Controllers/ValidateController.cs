using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrekkEnterpriseV4.Models;

namespace TrekkEnterpriseV4.Controllers
{
    public class ValidateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Validate
        [AllowAnonymous]    
        [HttpGet]
        public JsonResult Index(string email)
        {
            if (email == null) return Json(new receipt("e", string.Empty, "", "Email Required"), JsonRequestBehavior.AllowGet);

            var receipt = ValidateUser(email);
            return Json(receipt, JsonRequestBehavior.AllowGet);
        }

        private receipt ValidateUser(string email)
        {

            var baseURL = "https://trekkenterprise.com/appdownloads/";
            var status = "n";
            var url = string.Empty;
            var msg = string.Empty;
            var ver = string.Empty;

            try
            {
                var user = db.Users.Where(x => x.Email == email).FirstOrDefault();

                if (user == null)
                {
                    status = "e";
                    msg = "Email does not exist";
                }
                else if (user.Enabled && string.IsNullOrWhiteSpace(user.AccessCode))
                {
                    status = "e";
                    msg = "User has no entry code";
                }
                else if (!user.Enabled)
                {
                    status = "n";
                    msg = "User is disabled";
                }
                else if (user.Enabled && !string.IsNullOrWhiteSpace(user.AccessCode))
                {
                    status = "y";
                    url = HttpUtility.UrlEncode(baseURL + user.AccessCode);
                }
            }
            catch (Exception ex)
            {
                var msgStr = ex.Message; //For future use
                status = "e";
                msg = "General in validation routine";
            }

            return new receipt(status, url, ver, msg);
        }
    }

    public class receipt
    {
        //status Valid = "y", Invalid="n", Error="e"
        public string status { get; set; }
        public string url { get; set; }
        public string ver { get; set; }
        public string msg { get; set; }

        public receipt(string p_status, string p_url, string p_ver, string p_msg)
        {
            status = p_status;
            url = p_url;
            ver = p_ver;
            msg = p_msg;
        }
    }


}