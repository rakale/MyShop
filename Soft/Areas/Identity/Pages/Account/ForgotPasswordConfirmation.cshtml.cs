using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Soft.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel {
        public void OnGet() {
        }
    }
}
