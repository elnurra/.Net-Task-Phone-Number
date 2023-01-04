﻿using FirstDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDataApp.CRUD
{
    internal class BaseCRUD
    {
      

        public static void UserAdd(string name, string surname, string mail,string phone) {
            UsersContext db = new UsersContext();
            object addUser = db.Users.Add(new()
            {
                FirstName=name,
                LastName=surname,
                Mail=mail,
                Phone=phone
            });
            bool result = db.SaveChanges()>0;
            Console.WriteLine(result ? "                                           Successfully registered" : "Somethis is wrong");
                                        
         }

        public static void ListUsers()
        {
            
            UsersContext db = new UsersContext();
            var listUsers = db.Users.ToList();
            Console.WriteLine($"{"ID",-10} {"Firstname",-30} {"Lastname",-30} {"Mail",-30} {"Phone \n"}");
            foreach (var user in listUsers)
            {
                
                Console.WriteLine($"{user.Id,-10} {user.FirstName,-30} {user.LastName,-30} {user.Mail,-30} {user.Phone}");
            }
        }

        public static void UpdateUsers(int Id,string updatedName,string updatedSurName,string updatedMail,string updatedPhone)
        {
            UsersContext db = new UsersContext();
            var updateUser = db.Users.Find(Id);
            updateUser.FirstName = updatedName;
            updateUser.LastName = updatedSurName;
            updateUser.Mail= updatedMail;
            updateUser.Phone= updatedPhone;
            bool result = db.SaveChanges()>0;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(result? "Successfully updated" : "System error 404: ");

        }

        public static void DeleteUsers(int Id)
        {
            UsersContext db = new UsersContext();
            var deleteUser = db.Users.Find(Id);
            db.Users.Remove(deleteUser);
            bool result = db.SaveChanges()>0;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(result ? "Successfully deleted" : "System error 404: ");

        }







    }
}
