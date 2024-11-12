using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class AnswerSQL : SharedSQL
    {
        public static Answer FetchAnswerFromID(int aid)
        {
            Answer ret = null;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM answers WHERE answer_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", aid);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                ret = new Answer(aid, reader.GetInt32(1), reader.GetInt32(2),reader.GetString(3), reader.GetDateTime(4));

            }
            con.Close();
            return ret;
        }
        public static List<Answer> FetchAllAnswersFromQuestion(int qid)
        {
            List<Answer> answers = new List<Answer>();
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM answers WHERE question_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", qid);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while(reader.Read())
                answers.Add(new Answer(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4)));

            }
            con.Close();
            return answers;
        }
        public static Answer AddAnswer(Answer ans)
        {
            DateTime date = DateTime.Now;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO answers (user_id, question_id, content, date) VALUES (@user_id, @question_id, @content, @date); SELECT LAST_INSERT_ID();", con);
            cmd.Parameters.AddWithValue("@content", ans.Contents);
            cmd.Parameters.AddWithValue("@question_id", ans.QuestionID);
            cmd.Parameters.AddWithValue("@user_id", ans.UserID);
            cmd.Parameters.AddWithValue("@date", date);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return new Answer(id, ans.UserID, ans.QuestionID, ans.Contents, date);

        }

    }
}