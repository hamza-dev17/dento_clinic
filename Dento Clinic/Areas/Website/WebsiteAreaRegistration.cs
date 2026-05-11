using System.Web.Mvc;

public class WebsiteAreaRegistration : AreaRegistration
{
    public override string AreaName => "Website"; // The name of the area

    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Website_default", // Name of the route
            "{controller}/{action}/{id}", // URL pattern for this area
            new { action = "Index", id = UrlParameter.Optional } // Default action and parameters
        );
    }
}
