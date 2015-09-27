namespace PhoenixBootstrap.Controllers
{
    using System.Web.Mvc;
    using Phoenix.Data;
    using Phoenix.Models;

    [Authorize(Roles = "Administrator")]
    [ValidateInput(false)]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IPhoenixData data)
            : base(data)
        {

        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.Data.AdministrationLogs.Add(
                new AdministrationLog
                {
                    IpAddress = this.Request.UserHostAddress,
                    Url = this.Request.RawUrl,
                    UserId = this.UserProfile.Id,
                    RequestType = this.Request.RequestType,
                    PostParams = this.Request.Form.ToString(),
                });

            this.Data.SaveChanges();

            base.OnActionExecuted(filterContext);
        }
    }
}