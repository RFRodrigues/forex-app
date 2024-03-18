using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forex_app.Models
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Login Login { get; set; }

        public IActionResult OnPost(Login login)
        {
            if (!isValidLogin(login) && !ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Home");
        }

        public bool isValidLogin(Login login)
        {
            // Set hardcoded login
            string clientId = "C14557";
            string userId = "USER23";
            string password = "ExamplePw";
            bool isValid = true;

            if(!string.Equals(login.Password, password))
            {
                ModelState.AddModelError("Login.Password", "Incorrect Password");
                isValid = false;
            }
            if (!string.Equals(login.ClientId, clientId))
            {
                ModelState.AddModelError("Login.ClientId", "Invalid Client ID");
                isValid = false;
            }
            if (!string.Equals(login.UserId, userId))
            {
                ModelState.AddModelError("Login.UserId", "Invalid User ID");
                isValid = false;
            }
            return isValid;
        }
    }
}
