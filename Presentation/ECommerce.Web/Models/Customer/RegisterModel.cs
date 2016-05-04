using ECommerce.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models.Customer
{
    public partial class RegisterModel:BaseECModel
    {
        public RegisterModel()
        {

        }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string EMail { get; set; }

        public string Password { get;set;}

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }
    }
}