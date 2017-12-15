using AKQA.CodeTest.Service.Models;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace AKQA.CodeTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Convert(PersonInput personInfo)
        {
            string URL = string.Format("http://{0}:{1}/api/converter/Currency/{2}/",
                Request.Url.Host, 53901, personInfo.Amount);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                {
                    personInfo.WordAmount = stream.ReadToEnd();
                }
            }

            return View("~/Views/Home/Index.cshtml", personInfo);
        }
    }
}