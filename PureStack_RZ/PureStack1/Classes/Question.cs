using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PureStack.Classes;
namespace PureStack.Classes
{
    public class Question
    {
        private int m_questionID;
        private string m_contents;
        private string m_header;
        private User m_user;
        private DateTime m_date;
        private List<Answer> m_answers;
        private int m_numAnswers;
        public Question(int questionID, string contents, string header, User user, DateTime date, int numAnswers=-1)
        {
            m_questionID = questionID;
            m_contents = contents;
            m_header = header;
            m_user = user;
            m_date = date;
            m_answers = new List<Answer>();
            m_numAnswers = numAnswers;
        }
        public Question(int questionID, string contents, string header, User user, DateTime date, List<Answer> answers) : 
            this(questionID, contents, header, user, date)
        {        
            m_answers = answers;
            m_numAnswers = answers.Count;
        }
        
        public int QuestionID { get => m_questionID;}
        public string Contents { get => m_contents; set => m_contents = value; }
        public string Header { get => m_header; set => m_header = value; }
        public User User { get => m_user;}
        public DateTime Date { get => m_date; set => m_date = value; }
        public int NumAnswers { get => m_numAnswers; set => m_numAnswers = value; }
        public List<Answer> Answers { get => m_answers; }
        public void SetAnswers(List<Answer> value)    
        {
                m_answers = value;
                m_numAnswers = m_answers.Count;
        }
        

        public void AddAnswer(Answer ans)
        {
            this.Answers.Add(ans);
            m_numAnswers++;
        }
        public int GetScore()
        {
            return VotesSQL.GetQuestionScore(this);
        }
        

    }
}