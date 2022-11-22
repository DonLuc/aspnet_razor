using LucasWeb.Data;
using LucasWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LucasWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        
        public Category Category { get; set; }
        private readonly ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            //Category = _db.Category.Find(id);
            Category = _db.Category.FirstOrDefault(category => category.Id == id);
            if (ModelState.IsValid)
            {
                foreach (var modelValue in ModelState.Values)
                {
                    modelValue.Errors.Clear();
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(String.Empty, "The DisplayOrder cannot exactly match the name");
            }
            if (ModelState.IsValid) {
                foreach (var modelValue in ModelState.Values) { 
                    modelValue.Errors.Clear();
                }
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
