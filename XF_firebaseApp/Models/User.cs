using System;
namespace XF_firebaseApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool isAdmin { get; set; }
    }
}
