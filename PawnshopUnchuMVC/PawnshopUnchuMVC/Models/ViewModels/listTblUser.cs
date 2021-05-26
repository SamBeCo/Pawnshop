using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PawnshopUnchuMVC.Models.ViewModels
{
    public class listTblUser
    {
        public string ID { get; set; }
        public string userEmail { get; set; }
        public string userKey { get; set; }
        public TypeUser userType { get; set; }

    }
    public enum TypeUser
    {
        Admin,
        User
    }
}