using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class UserSQL : SharedSQL
    {
        private static User FetchUser(string filter, Dictionary<string, object> parameters)
        {
            User user = null;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT user_id, username, email, picture FROM users WHERE " + filter, con);
            foreach (KeyValuePair<string, object> par in parameters)
            {
                cmd.Parameters.AddWithValue(par.Key, par.Value);
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), "***");
                //reader.
               if (!reader.IsDBNull(3))          
                    user.Picture = reader.GetString(3);

            }
            con.Close();
            return user;
        }
        public static User FetchUserFromID(int id)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@id", id);
            return FetchUser(@"user_id = @id;", dict);
        }
        public static User FetchUserFromUsername(string username)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@un", username);
            return FetchUser(@"username = @un;", dict);
        }
        public static bool IsUserAdmin(int id)
        {
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT admin FROM users WHERE user_id = @id", con);    
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bool admin = reader.GetInt32(0) == 1;
            con.Close();
            return admin;
        }
        public static bool CheckIfUserExists(string un, string em)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@un", un);
            dict.Add("@em", em);
            return FetchUser(@"username = @un or email = @em;", dict) != null;
        }
        public static User CheckUserCredentials(string un, string pw)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@un", un);
            dict.Add("@pw", pw);
            return FetchUser(@"username = @un AND password = @pw;", dict);
        }
        public static User CreateUser(User user)
        {
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO users(username, email, password, picture) VALUES(@un, @em, @pw, @pc); SELECT LAST_INSERT_ID();", con);
            cmd.Parameters.AddWithValue("@un", user.Username);
            cmd.Parameters.AddWithValue("@em", user.Email);
            cmd.Parameters.AddWithValue("@pw", user.Password);
            cmd.Parameters.AddWithValue("@pc", user.Picture);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return new User(id, user.Username, user.Email, user.Password);
        }
        public static List<Answer> GetAllUserAnswers(User user)
        {
            List<Answer> answers = new List<Answer>();
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM answers WHERE user_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    answers.Add(new Answer(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4)));

            }
            con.Close(); 
            return answers;
        }
        public static List<Question> GetAllUserQuestions(User user)
        {
            List<Question> questions = new List<Question>();
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT * FROM questions WHERE user_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                    questions.Add(new Question(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), UserSQL.FetchUserFromID(reader.GetInt32(3)), reader.GetDateTime(4)));

            }
            con.Close();
            return questions;
        }
        public static int GetUserVoteCount(User user)
        {
            int count = 0;
            MySqlConnection con = OpenConnection();
            MySqlCommand cmd = new MySqlCommand(@"SELECT COUNT(*) FROM votes WHERE user_id = @id;", con);
            cmd.Parameters.AddWithValue("@id", user.UserID);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            count = reader.GetInt32(0);      

            con.Close();
            return count;
        }
        public static int ReturnUserScore(User user)
        {
            int score = 0;
            List<Answer> answers = GetAllUserAnswers(user);
            List<Question> questions = GetAllUserQuestions(user);
            foreach (Answer ans in answers)
                score += ans.GetScore();
            foreach (Question que in questions)
                score += que.GetScore();
            return score;
        }
        public static UserStats GetUserStats(User user)
        {
            return new UserStats(user, GetAllUserAnswers(user).Count, GetAllUserQuestions(user).Count, GetUserVoteCount(user));
        }
    }
}