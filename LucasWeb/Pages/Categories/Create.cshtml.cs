using LucasWeb.Data;
using LucasWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LucasWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        
        public Category Category { get; set; }
        private readonly ApplicationDBContext _db;
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(String.Empty, "The DisplayOrder cannot exactly match the name");
            }
            if (ModelState.IsValid) { 
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
