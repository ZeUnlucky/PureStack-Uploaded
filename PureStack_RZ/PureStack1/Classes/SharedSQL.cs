using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PureStack.Classes
{
    public class SharedSQL
    {
        public const string CON_STR = @"server=localhost;user id=root;persistsecurityinfo=True;database=forum;password=izhar77";
        public static MySqlConnection OpenConnection()  
        {
            try
            {
                MySqlConnection con = new MySqlConnection(CON_STR);
                con.Open();
                return con;
            }
            catch (MySqlException e)
            {
                throw new DALException(e);
            }
        }
    }
}
