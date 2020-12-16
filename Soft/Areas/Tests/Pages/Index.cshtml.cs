using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soft.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soft.Areas.Tests.Pages {
    public class IndexModel : PageModel {
        private readonly Soft.Data.SoftContext _context;

        public IndexModel(Soft.Data.SoftContext context) {
            _context = context;
        }

        public IList<TestData> TestData { get; set; }

        public async Task OnGetAsync() {
            TestData = await _context.TestData.ToListAsync();
        }
    }
}
