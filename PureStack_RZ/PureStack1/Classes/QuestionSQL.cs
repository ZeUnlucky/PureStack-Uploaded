using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class QuestionSQL : SharedSQL
    {
        private static List<Question> FetchQuestions(string query, Dictionary<string, object> parameters)
        {
            List<Question> questions = new List<Question>();
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Key, par.Value);
                }
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Question q = new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), UserSQL.FetchUserFromID(reader.GetInt32(3)), reader.GetDateTime(4));
                    
                    if (reader.FieldCount >= 6)
                        q.NumAnswers = (int)reader.GetInt32(5);
                    questions.Add(q);
                }
            }
            con.Close();
            return questions;
        }
        public static Question FetchQuestionFromID(int id, bool fetchAnswers = false)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@id", id);
            Question question = FetchQuestions(@"SELECT * FROM questions WHERE question_id = @id;", dict)[0];

            if (fetchAnswers)
                question.SetAnswers(AnswerSQL.FetchAllAnswersFromQuestion(id));

            return question;
        }
        public static List<Question> ShowAllQuestions()
        {

            List<Question> questions = FetchQuestions(@"SELECT question_id, contents, header, user_id, date, (SELECT count(*) FROM forum.answers WHERE question_id = q.question_id) as numAnswers FROM forum.questions q;", null);   
            return questions;
        }

        public static Question CreateQuestion(string content, string header, int uid)
        {
            DateTime date = DateTime.Now;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO questions (contents, header, user_id, date) VALUES (@contents, @header, @user_id, @date); SELECT LAST_INSERT_ID();", con);
            cmd.Parameters.AddWithValue("@contents", content);
            cmd.Parameters.AddWithValue("@header", header);
            cmd.Parameters.AddWithValue("@user_id", uid);
            cmd.Parameters.AddWithValue("@date", date);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return new Question(id, content, header, UserSQL.FetchUserFromID(1), date);
            
        }
        public static int[] GetAnsweredQuestions()
        {
            int answered = 0;
            int notans = 0;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT IF(isnull(a.question_id), 'Not Answered', 'Answered') as IsAns, count(distinct q.question_id) FROM forum.questions q 
                LEFT OUTER JOIN forum.answers a ON q.question_id = a.question_id
                GROUP BY IsAns
                ORDER BY IsAns;"
            , con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetString(0).Equals("Answered"))
                        answered = reader.GetInt16(1);
                    else if (reader.GetString(0).Equals("Not Answered"))
                        notans = reader.GetInt16(1);
                }
            }
            con.Close();
            int[] ret = new int[2];
            ret[0] = answered;
            ret[1] = notans;
            return ret;
        }
        public static List<Question> GetUserLatestQuestions(User user, int limit)
        {           
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@id", user.UserID);
            dict.Add("@lim", limit);
            List<Question> questions = FetchQuestions(@"SELECT * FROM forum.questions WHERE user_id = @id ORDER BY date DESC LIMIT @lim;", dict);

            return questions;
        }

        public static void DeleteQuestion(int qid)
        {
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"DELETE FROM questions WHERE question_id = @qid;", con);
            cmd.Parameters.AddWithValue("@qid", qid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}