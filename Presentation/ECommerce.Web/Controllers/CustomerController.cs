using ECommerce.Core.Domain.Customers;
using ECommerce.Web.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class CustomerController : BasePublicController
    {
        private readonly CustomerSetting _customerSetting;

        public CustomerController()
        {

        }
        public CustomerController(CustomerSetting customerSetting)
        {
            this._customerSetting = customerSetting;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        #region Register
        public ActionResult Register()
        {
            //if (_customerSetting.UserRegistrationType == UserRegistrationType.Disabled)
            //    return RedirectToRoute("");

            var model = new RegisterModel();
            
            return View(model);
        }
        #endregion
    }
}