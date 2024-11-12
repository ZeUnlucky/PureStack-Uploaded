using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using PureStack;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class ActionsModel : SharedModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnGetLogOut()
        {
            LogOutUser();
            return RedirectToPage("Index");
        }
        public JsonResult OnGetVoteQuestion(int qid, int isGood) 
        {
            Question q = QuestionSQL.FetchQuestionFromID(qid,false);
           

            User user = UserSQL.FetchUserFromID(GetUserID());

            VotesSQL.VoteForQuestion(q, user, isGood==1);

            return new JsonResult(VotesSQL.GetQuestionScore(q));
        }

        public JsonResult OnGetVoteAnswer(int aid, int isGood)
        {
            Answer ans = AnswerSQL.FetchAnswerFromID(aid);
            
            User user = UserSQL.FetchUserFromID(GetUserID());

            VotesSQL.VoteForAnswer(ans, user, isGood == 1);

            return new JsonResult(VotesSQL.GetAnswerScore(ans));
        }
    }
}
