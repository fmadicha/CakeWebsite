using CakeWebsite.Data;
using CakeWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CakeWebsite.Controllers
{
    public class CategoryController : Controller
    {private readonly AppDbContext _context;        
        public CategoryController(AppDbContext context) 
        {
                _context = context; 
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _context.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) // if valid whatever needs to be populated is done
            {
                _context.Categories.Add(obj);// if not valid it will not be saved in the db
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
                return View();
            
        }
        //Get
        public IActionResult Edit(int id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _context.Categories.Find(id);
            // Category categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == id);
            //Category categoryFromDb = _context.Categories.Where(c => c.Id == id),FirstOrDefault();
            if (categoryFromDb == null) 
            { 
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) // if valid whatever needs to be populated is done
            {
                _context.Categories.Update(obj);// if not valid it will not be saved in the db
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _context.Categories.Find(id);
            // Category categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == id);
            //Category categoryFromDb = _context.Categories.Where(c => c.Id == id),FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {   
            Category obj= _context.Categories.Find(id);
            if (obj == null)
            {  
                return NotFound(); 
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
