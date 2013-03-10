using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Linq;

using RestaurantWebReservation.Application.Role;
using RestaurantWebReservation.Application.BasicDataStractrue;
using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.Role
{
    public class Admin : User
    {
        public Admin()
        { }

        public Admin (string pName, string pPwd, string pMail)
        {
            name = pName;
            pwd = pPwd;
            mail = pMail;

        }

        public static Admin Login(string pName, string pPwd)
        {
            Admin admin = null;
            bool? isAdmin = false;
            DataContextDataContext dc = new DataContextDataContext();

            ISingleResult<is_adminResult> rs = dc.is_admin(pName, pPwd, ref isAdmin);

            if (isAdmin == true)
            {
                foreach (is_adminResult r in rs)
                {
                    admin = new Admin(r.name, r.pwd, r.mail);
                }
            }
            else
            { }

            return admin;
        }

        //public Dictionary<string, DateTime> GetBusinessTime()
        //{
        //    Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
        //    DataContextDataContext dc = new DataContextDataContext();
        //    ISingleResult<select_all_businesstimeResult> rs = dc.select_all_businesstime();
        //    foreach (select_all_businesstimeResult r in rs)
        //    {
        //        dictionary.Add(r.keyword, r.time_end);
        //    }
        //    return dictionary;
        //}

        public void ModifyBuinessTime(Dictionary<string, DateTime> pDict)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.truncate_business_time();
            foreach (KeyValuePair<string, DateTime> d in pDict)
            {
                dc.insert_business_time(d.Key, d.Value);
            }
        }

		//Function: add a new dish to the system
        public bool AddDish(Dish pDish)
        {
            bool isInsert = false;
            try
            {
                DataContextDataContext dc = new DataContextDataContext();
                dc.insert_dish(pDish.name, pDish.description, pDish.price, pDish.pictPath, pDish.popularity);
                isInsert = true;

                foreach (Tag t in pDish.tagList)
                {
                    dc.update_tag_pupularity_or_insert(t.name);
                    dc.insert_taganddish(t.name, pDish.name);
                }
            }
            catch (Exception ex)
            { }

            return isInsert;
        }

		//Function: add a new table to the system
        public bool AddTable(SysTable pTable)
        {
            bool isInsert = false;
            try
            {
                DataContextDataContext dc = new DataContextDataContext();
                dc.insert_table(pTable.id, pTable.name, pTable.seat, pTable.pictPath, (int?)pTable.state);
                isInsert = true;
            }
            catch (Exception ex)
            { }

            return isInsert;
        }


        public void ModifyDish(Dish pD)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_dish(pD.name, pD.description, pD.price, pD.pictPath, pD.popularity);
        }

        public void DeleteDish(string pName)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.delete_dish(pName);
        }

		//Function: register a new manager of the system
		//Return: a manager newd if the record is creaded successfully
		//        null if returned if the manager with a same name exists in db
        public Manager RegisterManager(string pName, string pPwd, string pMail)
        {
            Manager manager = null;
            bool? isExist = false;

            DataContextDataContext dc = new DataContextDataContext();
            dc.is_registered(pName, ref isExist);

            if (isExist == true)
            { } //manager = null
            else // not exist, can insert
            {
                try
                {
                    dc.insert_manager(pName, pPwd, pMail);
                    manager = new Manager(pName, pPwd, pMail);
                }
                catch (Exception ex)
                { } //custom = null;

            }

            return manager;
        }


        public void ModifyCustom(Customer pCustom)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_user(pCustom.name, pCustom.pwd, pCustom.mail);
        }

        public void ModifyManager(Manager pManager)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_user(pManager.name, pManager.pwd, pManager.mail);
        }

        public void DeleteUser(string pName)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.delete_user(pName);
        }

        public void DeleteComment(Guid pId)
        {
            DataContextDataContext dc = new DataContextDataContext();
            dc.delete_comment(pId);
        }

        //AdminService adminService = new AdminService();
    }
}