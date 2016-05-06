using ECommerce.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Models.Customer
{
    public partial class RegisterModel : BaseECModel
    {
        public RegisterModel()
        {

        }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "真实姓名")]
        public string FirstName { get; set; }

        [Display(Name = "邮箱")]
        public string EMail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "性别")]
        public string Gender { get; set; }
        [Display(Name = "电话")]
        public string Phone { get; set; }
    }
}