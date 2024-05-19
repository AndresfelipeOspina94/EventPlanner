using EventPlanner.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventPlanner.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly EventPlannerContext _context;

        public LoginModel(EventPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email && u.Password == Input.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");

                    await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity));

                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
                return Page();
            }

            return Page();
        }
    }
}
