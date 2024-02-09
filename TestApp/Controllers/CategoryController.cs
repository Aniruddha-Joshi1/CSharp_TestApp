using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Data;

namespace TestApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) {
            bool success = int.TryParse(obj.Name, out _);
            TempData["success"] = "Category created successfully";
            Console.WriteLine(success);
            if (success)
            {
                ModelState.AddModelError("Name", "The Name cannot be a number");
            }
            else if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Edit(int ?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category catgeoryFromDb = _db.Categories.Find(id);
            if(catgeoryFromDb == null)
            {
                return NotFound();
            }
            return View(catgeoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            TempData["success"] = "Category edited successfully";
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? DeleteFromDb = _db.Categories.Find(id);
            if (DeleteFromDb == null)
            {
                return NotFound();
            }
            return View(DeleteFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int ?id)
        {
            TempData["success"] = "Category deleted successfully";
            Category ?obj= _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}
