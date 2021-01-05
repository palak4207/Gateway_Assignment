using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiDemo.Models;
namespace ApiDemo
{ 
    public class UserCheck :IDisposable
    {
        //Check Login Credentials is correct or not
        ProductDbApiEntities context = new ProductDbApiEntities();
        public admin ValidateUser(string username, string password)
        {
            return context.admins.FirstOrDefault(user =>
            user.username.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.password == password);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}