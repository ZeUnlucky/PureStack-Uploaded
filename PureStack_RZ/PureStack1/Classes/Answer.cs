using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using PureStack.Classes;

namespace PureStack.Classes
{
    public class Answer
    {
        private int m_answerid;
        private int m_userID;
        private int m_question;
        private string m_contents;
        private DateTime m_date;
        private User m_user = null;

        public Answer(int answerid, int user, int question, string contents, DateTime date)
        {
            m_answerid = answerid;
            m_userID = user;
            m_question = question;
            m_contents = contents;
            m_date = date;
        }

        public int AnswerID { get => m_answerid; set => m_answerid = value; }
        public int UserID { get => m_userID; set => m_userID = value; }
        public int QuestionID { get => m_question; set => m_question = value; }
        public string Contents { get => m_contents; set => m_contents = value; }
        public DateTime Date { get => m_date; set => m_date = value; }
        public int GetScore()
        {
            return VotesSQL.GetAnswerScore(this);
        }
        public User GetUser()
        {
            if (m_user == null)
            {
                m_user = UserSQL.FetchUserFromID(UserID);
            }
            return m_user;
        }
    }
}