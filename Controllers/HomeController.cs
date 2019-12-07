using LocalHackTweetAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LocalHackTweetAnalysis.Controllers
{
    public class HomeController : Controller
    {
        private readonly int pageSize = 10;
        public ActionResult Index()
        {
            return View();
        }

     
        public async Task<ActionResult> Search(SearchDocModel searchmodel)
        {
            AzSearchModel azSearchModel = new AzSearchModel { search = searchmodel.search, skip = searchmodel.pageNo * pageSize, top = pageSize };

            var items = await SearchAPI.GetDocListAsync(azSearchModel);
            ViewData["pageNo"] = searchmodel.pageNo;
            ViewData["IsSearchQuery"] = (searchmodel.search == null) ? string.Empty : searchmodel.search;
            ViewData["pageSize"] = pageSize;
            ViewData["totalRemainingPageSize"] = (int)Math.Ceiling((double)items.odatacount / pageSize) - searchmodel.pageNo;

            return View(items.value);
        }
    }
}