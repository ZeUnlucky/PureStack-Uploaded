using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class StatsModel : PageModel
    {
        private Dictionary<string, int> _leaderboard;
        public void OnGet()
        {
            _leaderboard = VotesSQL.GetLeaderboard();
        }
        public string[] GetLeaderboardStrings()
        {
            string[] result = new string[2];
            result[0] = "[";
            result[1] = "[";
            foreach (KeyValuePair<string, int> val in _leaderboard)
            {
                result[0] += "\'" + val.Key + "\',";
                result[1] += val.Value + ",";
            }
            result[0] =result[0].Remove(result[0].Length - 1, 1);
            result[1] = result[1].Remove(result[1].Length - 1, 1);
            result[0] += "]";
            result[1] += "]";
            
            return result;
        }
        public string GetAnsweredQuestionsString()
        {
            string result = "[";
            int[] answered = QuestionSQL.GetAnsweredQuestions();
            result += answered[0] + "," + answered[1] + "]";
            return result;
        }
    }
}
