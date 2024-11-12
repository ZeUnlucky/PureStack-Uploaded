using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PureStack.Classes;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PureStack1.Pages
{
    public class SignUpModel : SharedModel
    {
        [BindProperty]
        [Required]
        public String UserName { get; set; }


        [StringLength(60, MinimumLength = 6)]
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [BindProperty]
        public IFormFile PFP { get; set; }

        private IHostingEnvironment _environment;

        public SignUpModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        
  
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (UserSQL.CheckIfUserExists(UserName, Email))
            {
                ModelState.AddModelError("UserName", "Username or email already taken.");
                return Page();
            }
            User user = new User(-1, UserName, Email, Password);
            user.Picture = "facepalm.jpg";
            if (PFP != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", PFP.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    PFP.CopyTo(fileStream);
                }
                user.Picture = PFP.FileName;
            }

            user = UserSQL.CreateUser(user);
            SetLoggedInUser(user);            
            return RedirectToPage("Index");
        }
    }
}
