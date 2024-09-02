using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POC.Entities;
using POC.Models;

namespace POC.Controllers
{
    [Authorize]
    public class CRUDController : Controller
    {
        private readonly AppDbContext _context;

        public CRUDController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.CrudItems.ToList();
            return View(items);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CrudItem model)
        {
            if (ModelState.IsValid)
            {
                
                TimeZoneInfo indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime currentTimeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, indiaTimeZone);

               
                model.DueDate = model.DueDate.Date.Add(currentTimeInIndia.TimeOfDay);

                _context.CrudItems.Add(model);
                _context.SaveChanges();
                return RedirectToAction("SecurePage", "Account");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.CrudItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item); 
        }

        [HttpPost]
        public IActionResult Edit(CrudItem model)
        {
            if (ModelState.IsValid)
            {
               
                TimeZoneInfo indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime currentTimeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, indiaTimeZone);

                model.DueDate = model.DueDate.Date.Add(currentTimeInIndia.TimeOfDay);

                _context.CrudItems.Update(model);
                _context.SaveChanges();
                return RedirectToAction("SecurePage", "Account");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _context.CrudItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item); 
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.CrudItems.Find(id);
            if (item != null)
            {
                _context.CrudItems.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("SecurePage", "Account");
        }

        public IActionResult Details(int id)
        {
            var item = _context.CrudItems.Find(id); 
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        public IActionResult SecurePage(string statusFilter)
        {
            ViewBag.StatusFilter = statusFilter ?? "All";

            var statusList = new List<SelectListItem>
            {
                 new SelectListItem { Value = "All", Text = "All" },
                 new SelectListItem { Value = "Pending", Text = "Pending" },
                 new SelectListItem { Value = "Completed", Text = "Completed" }
            };

            ViewBag.StatusList = new SelectList(statusList, "Value", "Text", statusFilter);

            var items = _context.CrudItems.AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                items = items.Where(i => i.Status == statusFilter);
            }

            return View(items.ToList());
        }
    }
}
