using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSo.Controllers
{
    public class TranDausController : Controller
    {
        private readonly QuanLyHoiThaoDBContext _context;

        public TranDausController(QuanLyHoiThaoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
