using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.Application.Service;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.Role
{
    public class User
    {
        public string name { get; set; }
        public string pwd { get; set; }
        public string mail { get; set; }


        //Function: initialize a concrete user, return it as use of this session, if the user is valid
		//Paramaters:
		//Return: concrete user type, (Customer or Manager)
		//    null when the user is invalid
        //用户身份验证，根据名字密码查数据库，合法的话，返回出manager或者customer
        //不合法返回NUll
        public static User Login(string pName, string pPwd)
        {
            User user = null;
            DataContextDataContext dc = new DataContextDataContext();
            bool? isValid = false;
            ISingleResult<is_valid_userResult> rs = dc.is_valid_user(pName, pPwd, ref isValid);

            if (isValid == true)
            {
                foreach (is_valid_userResult s in rs)
                {
                    if (s.type == 1)
                    {
                        user = new Customer(s.name, s.pwd, s.mail);
                    }
                    else if (s.type == 2)
                    {
                        user = new Manager(s.name, s.pwd, s.mail);
                    }
                    else
                    { }

                }

            }
            else //invalid
            {}
            return user;

        }
        

        //public void Logout()
        //{}

		//Function: initialize a customer, and insert a new record of custoemr into db
		//Return: custoemr newd if user name is valid
		//    null if pName exists in db

        //user注册后，返回custoemr，把注册记录插到SysUser表
        public static Customer Register(string pName, string pPwd, string pMail)
        {
            Customer custom = null;
            bool? isExist = false;

            DataContextDataContext dc = new DataContextDataContext();
            dc.is_registered(pName, ref isExist);

            if (isExist == true)
            { } //custom = null
            else // not exist, can insert
            {
                try
                {
                    dc.insert_customer(pName, pPwd, pMail);
                    custom = new Customer(pName, pPwd, pMail);
                }
                catch (Exception ex)
                { } //custom = null;

            }

            return custom;
        }
    }
}