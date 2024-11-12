using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PureStack.Classes;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class VotesSQL :SharedSQL
    {
        public static int GetQuestionScore(Question q)
        {
            int Score = 0;

            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT good_bad FROM forum.votes where thread_id=@id and is_question=1;", con);
            cmd.Parameters.AddWithValue("@id", q.QuestionID);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                        Score++;
                    else
                        Score--;
                }
            }
            con.Close();
            return Score;
        }
        public static int GetAnswerScore(Answer ans)
        {
            int Score = 0;

            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT good_bad FROM forum.votes where thread_id=@id and is_question=0;", con);
            cmd.Parameters.AddWithValue("@id", ans.AnswerID);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                        Score++;
                    else
                        Score--;
                }
            }
            con.Close();
            return Score;
        }
        public static void VoteForQuestion(Question q, User user, bool Good)
        {
            if (user == null)
                return;

            int good = 1;
            if (!Good)
                good = 0;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO votes (thread_id, user_id, is_question, good_bad) VALUES (@qid, @uid, 1, @good_bad) ON DUPLICATE KEY UPDATE good_bad = @good_bad;", con);
            cmd.Parameters.AddWithValue("@qid", q.QuestionID);
            cmd.Parameters.AddWithValue("@uid", user.UserID);
            cmd.Parameters.AddWithValue("@good_bad", good);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void VoteForAnswer(Answer ans, User user, bool Good)
        {
            if (user == null)        
                return;

            int good = 1;
            if (!Good)
                good = 0;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO votes (thread_id, user_id, is_question, good_bad) VALUES (@aid, @uid, 0, @good_bad) ON DUPLICATE KEY UPDATE good_bad = @good_bad;", con);
            cmd.Parameters.AddWithValue("@aid", ans.AnswerID);
            cmd.Parameters.AddWithValue("@uid", user.UserID);
            cmd.Parameters.AddWithValue("@good_bad", good);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static Dictionary<string, int> GetLeaderboard()
        {
            Dictionary<string, int> leaderboard = new Dictionary<string, int>();
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT u.username, q.user_id, SUM(IF(good_bad=1, 1, -1)) as score FROM forum.questions q 
                INNER JOIN forum.votes v ON q.question_id = v.thread_id
                INNER JOIN forum.users u ON q.user_id = u.user_id
                where v.is_question=1
                GROUP BY q.user_id
                ORDER BY score DESC;"
            , con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    leaderboard.Add(reader.GetString(0), reader.GetInt32(2));
                }
            }
            con.Close();
            return leaderboard;
        }
        
    }
}