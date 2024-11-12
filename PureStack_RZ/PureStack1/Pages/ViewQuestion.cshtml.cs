using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class ViewQuestionModel : SharedModel
    {
        [BindProperty]
        [Required]
        [StringLength(5600, MinimumLength = 10)]
        public String AnswerText { get; set; }

        [BindProperty]
        public int QuestionID { get; set; }

        private Question _question;
        public Question GetQuestion()
        {
            if (_question == null)
            {
                _question = QuestionSQL.FetchQuestionFromID(QuestionID, true);
                
            }
            return _question;
        }
        public void OnGet(int qid)
        {
            if (qid <= 0)
            {
                Response.Redirect("Index");
                return;
            }
            QuestionID = qid;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Answer ans = AnswerSQL.AddAnswer(new Answer(-1, GetUserID(), QuestionID, AnswerText, DateTime.Now));
            return RedirectToPage("ViewQuestion", new { qid = QuestionID });
        }
        public IActionResult OnPostDelete(int id)
        {
            QuestionSQL.DeleteQuestion(id);
            return RedirectToPage("Index");
        }
            
        public bool CanUserDelete()
        {
            if (isLoggedIn())
                return GetUserID() == _question.User.UserID || UserSQL.IsUserAdmin(GetUserID());
            else
                return false;
        }

    }
}
