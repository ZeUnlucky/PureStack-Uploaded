using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class User
    {
        private const string DEFAULT_PICTURE = "facepalm.jpg";
        private int m_userID;
        private string m_username;
        private string m_email;
        private string m_password;
        private string m_picture;
        private bool m_admin;

        public User(int userID, string username, string email, string password)
        {
            m_userID = userID;
            m_username = username;
            m_email = email;
            m_password = password;
            m_picture = DEFAULT_PICTURE;
            m_admin = false;
        }
        
        public int UserID { get => m_userID;}
        public string Username { get => m_username; set => m_username = value; }
        public string Email { get => m_email;}
        public string Password { get => m_password; set => m_password = value; }
        public string Picture { get =>  m_picture; set => m_picture = value == "" ? DEFAULT_PICTURE : value; }
        public bool Admin { get => m_admin; set => m_admin = value; }
        public int Score { get => UserSQL.ReturnUserScore(this); }
        public string GetPicturePath()
        {
            return "Uploads/" + m_picture;
        }
    }
}