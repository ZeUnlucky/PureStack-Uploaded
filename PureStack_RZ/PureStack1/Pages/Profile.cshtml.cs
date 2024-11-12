using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class ProfileModel : SharedModel
    {
        private User _user;
        public User GetUser()
        { return _user; }
        //Stats
        //Recent posts
        public void OnGet(int uid)
        {
            if (uid == 0)
            {
                Response.Redirect("Index");
                return;
            }
            _user = UserSQL.FetchUserFromID(uid);
        }
        public List<Question> GetLatestPosts()
        {
            List<Question> questions = QuestionSQL.GetUserLatestQuestions(_user, 5);
            if (questions == null)
                questions = new List<Question>();
            return questions;
        }
        public UserStats GetStats()
        {
            return UserSQL.GetUserStats(_user);
        }
    }
}
