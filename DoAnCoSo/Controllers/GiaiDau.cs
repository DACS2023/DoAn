using DoAnCoSo.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSo.Controllers
{
    public class GiaiDau : Controller
    {
        QuanLyHoiThaoDBContext data = new QuanLyHoiThaoDBContext();

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FormCollection collection, GiaiDau gd)
        {
            
            if (collection == null)
            {
                return View();
            }
            return this.Create();
        }


        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
