using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppForo.Context;

namespace WebAppForo.Controllers
{
    public class ForoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
