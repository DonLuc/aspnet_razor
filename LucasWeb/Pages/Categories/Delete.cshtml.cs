using LucasWeb.Data;
using LucasWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LucasWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public Category Category { get; set; }
        private readonly ApplicationDBContext _db;

        public DeleteModel(ApplicationDBContext db)
        {
                _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.FirstOrDefault(c => c.Id == id);
            Console.WriteLine(id);
        }

        public async Task<IActionResult> OnPost() {
            _db.Category.Remove(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
