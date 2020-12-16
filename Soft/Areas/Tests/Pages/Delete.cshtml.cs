using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using System.Threading.Tasks;

namespace Soft.Areas.Tests.Pages {
    public class DeleteModel : PageModel {
        private readonly Soft.Data.SoftContext _context;

        public DeleteModel(Soft.Data.SoftContext context) {
            _context = context;
        }

        [BindProperty]
        public TestData TestData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            TestData = await _context.TestData.FirstOrDefaultAsync(m => m.Id == id);

            if (TestData == null) {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id) {
            if (id == null) {
                return NotFound();
            }

            TestData = await _context.TestData.FindAsync(id);

            if (TestData != null) {
                _context.TestData.Remove(TestData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
