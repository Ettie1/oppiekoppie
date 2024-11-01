using Microsoft.AspNetCore.Mvc;

namespace oppiekoppie.Controllers;

public class AppController: Controller
{
    public IActionResult RequestBooking(){
        return View();
    }
}