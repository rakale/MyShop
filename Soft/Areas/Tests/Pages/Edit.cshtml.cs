using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.Areas.Tests.Pages {
    public class EditModel : PageModel {
        private readonly Soft.Data.SoftContext _context;

        public EditModel(Soft.Data.SoftContext context) {
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(TestData).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!TestDataExists(TestData.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestDataExists(string id) {
            return _context.TestData.Any(e => e.Id == id);
        }
    }
}
