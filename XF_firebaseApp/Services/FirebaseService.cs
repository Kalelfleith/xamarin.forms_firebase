using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using XF_firebaseApp.Models;

namespace XF_firebaseApp.Services
{
    public class FirebaseService
    {
        FirebaseClient firebase =
           new FirebaseClient("https://xamarinfirestoreapp.firebaseio.com/");

        public async Task AddCUser(int userId, string name, string mail)
        {
            await firebase
               .Child("Contatos")
                  .PostAsync(new User() { UserId = userId, Name = name, Mail = mail });
        }

        public async Task<List<User>> GetUsers()
        {
            return (await firebase
              .Child("Users")
              .OnceAsync<User>()).Select(item => new User
              {
                  Name = item.Object.Name,
                  Mail = item.Object.Mail,
                  UserId = item.Object.UserId
              }).ToList();
        }

        public async Task<User> GetUser(int userId)
        {
            var users = await GetUsers();
            await firebase
              .Child("Users")
                .OnceAsync<User>();
            return users.Where(a => a.UserId == userId)
                .FirstOrDefault();
        }

        public async Task UpdateUser(int userId, string name, string mail)
        {
            var toUpdateUser = (await firebase
              .Child("Users")
                .OnceAsync<User>())
                   .Where(a => a.Object.UserId == userId).FirstOrDefault();
            await firebase
              .Child("Users")
                .Child(toUpdateUser.Key)
                  .PutAsync(new User()
                  { UserId = userId, Name = name, Mail = mail });
        }

        public async Task DeleteUser(int userId)
        {
            var toDeleteUser = (await firebase
              .Child("Users")
              .OnceAsync<User>())
                .Where(a => a.Object.UserId == userId).FirstOrDefault();
            await firebase.Child("Users")
                    .Child(toDeleteUser.Key)
                        .DeleteAsync();
        }
    }
}
