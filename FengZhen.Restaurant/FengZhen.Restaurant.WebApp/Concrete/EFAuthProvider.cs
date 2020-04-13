﻿using FengZhen.Restaurant.Domain.Concrete;
using FengZhen.Restaurant.WebApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FengZhen.Restaurant.WebApp.Concrete
{
    public class EFAuthProvider : IAuthProvider
    {
        public EFDbContext context { set; get; }

        public bool Authenticate(string username, string password)
        {
            var result = false;

            var adminuser = context.AdminUsers.FirstOrDefault(x => x.Username == username && x.Password == password);
            if(adminuser!=null)
            {
                result = true;
            }

            if(result)
            {
                FormsAuthentication.SetAuthCookie(username, true);
            }

            return result;
        }
    }
}