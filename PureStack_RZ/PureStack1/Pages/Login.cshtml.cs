using System;
using Microsoft.AspNetCore.Mvc;
using PureStack.Classes;
using System.ComponentModel.DataAnnotations;


namespace PureStack1.Pages
{
    public class LoginModel : SharedModel
    {
        [BindProperty]
        public String UserName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public String Password{ get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User user = UserSQL.CheckUserCredentials(UserName, Password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "User or password don't match");
                return Page();
            }
            SetLoggedInUser(user);
            

            return RedirectToPage("Index");
        }
    }
}
