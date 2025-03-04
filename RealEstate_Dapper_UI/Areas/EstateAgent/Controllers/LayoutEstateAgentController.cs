using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers {
    [Area("EstateAgent")]
    public class LayoutEstateAgentController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}
