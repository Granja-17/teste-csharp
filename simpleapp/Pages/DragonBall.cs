using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace simpleapp.Pages;

public class DragonBallModel : PageModel
{
    public void OnGet()
    {
        string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
        ViewData["TimeStamp"] = dateTime;
    }
}