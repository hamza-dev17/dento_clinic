using System.Web.Mvc;

public class AdminAreaRegistration : AreaRegistration
{
    public override string AreaName => "Admin"; // The name of the area

    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Admin_default", // Name of the route
            "Admin/{controller}/{action}/{id}", // URL pattern for this area
            new { action = "Index", id = UrlParameter.Optional } // Default action and parameters
        );
    }
}
