using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PureStack.Classes;

namespace PureStack1.Pages
{
    /*
     * Base class for all Razor model classes. Handles common aspects, in particular, session maanagement
     */
    public class SharedModel : PageModel
    {
        // Constants for storing user details in HTTP Sesssion
        private static string USERID = "UserId";
        private static string USERNAME = "User";

        public bool isLoggedIn()
        {
            return HttpContext.Session.GetString(USERNAME) != null;
        }

        public void SetLoggedInUser(User user)
        {           
            HttpContext.Session.SetString(USERNAME, user.Username);
            HttpContext.Session.SetInt32(USERID, user.UserID);
        }
        public void LogOutUser()
        {
            HttpContext.Session.Remove(USERNAME);
            HttpContext.Session.Remove(USERID);
        }
        public int GetUserID()
        {
            return isLoggedIn() ? (int)HttpContext.Session.GetInt32(USERID) : -1;
        }
        
    }
    
}
