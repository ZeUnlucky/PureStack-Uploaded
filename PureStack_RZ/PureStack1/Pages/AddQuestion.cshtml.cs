using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class AddQuestionModel : SharedModel
    {
        [BindProperty]
        [StringLength(5600, MinimumLength = 10)]
        [Required]
        public String QuestionContent{ get; set; }

        [BindProperty]
        [StringLength(100, MinimumLength = 0)]
        [Required]
        public String QuestionHeader { get; set; }

        public IActionResult OnGet()
        {
            if (!isLoggedIn())
                return RedirectToPage("Login");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Question question = QuestionSQL.CreateQuestion(QuestionContent, QuestionHeader, GetUserID());

            return RedirectToPage("ViewQuestion", new { qid = question.QuestionID });
        }
    }
}
