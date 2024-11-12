using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
namespace PureStack.Classes
{
    public class UserStats
    {
        private User _user;
        private int _numAnswers;
        private int _numQuestions;
        private int _numVotes;

        public UserStats(User user, int numAnswers, int numQuestions, int numVotes)
        {
            _user = user;
            _numAnswers = numAnswers;
            _numQuestions = numQuestions;
            _numVotes = numVotes;
        }
        public User User { get => _user; set => _user = value; }
        public int NumAnswers { get => _numAnswers; set => _numAnswers = value; }
        public int NumQuestions { get => _numQuestions; set => _numQuestions = value; }
        public int NumVotes { get => _numVotes; set => _numVotes = value; }
        public override string ToString()
        {
            return $"[NumAnswers = '{NumAnswers}', NumQuestions = '{NumQuestions}', NumVotes = '{NumVotes}']";
        }
    }
}
