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

        #region 构造函数
        public CustomerController()
        {

        }
        public CustomerController(CustomerSetting customerSetting)
        {
            this._customerSetting = customerSetting;
        }
        #endregion

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        #region 注册

        public ActionResult Register()
        {
            //if (_customerSetting.UserRegistrationType == UserRegistrationType.Disabled)
            //    return RedirectToRoute("");

            var model = new RegisterModel();
            PrepareCustomerRegisterModel(model, false);
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnUrl, bool captchaValid, FormCollection form)
        {
            return View();
        }
        #endregion

        #region 工具方法
        [NonAction]
        protected virtual void PrepareCustomerRegisterModel(RegisterModel model, bool excludeProperties,
            string overrideCustomCustomerAttributesXml = "")
        {
            if (model == null)
                throw new ArgumentNullException("model");

            // model.AllowCustomersToSetTimeZone = _dateTimeSettings.AllowCustomersToSetTimeZone;
            //foreach (var tzi in _dateTimeHelper.GetSystemTimeZones())
            //    model.AvailableTimeZones.Add(new SelectListItem { Text = tzi.DisplayName, Value = tzi.Id, Selected = (excludeProperties ? tzi.Id == model.TimeZoneId : tzi.Id == _dateTimeHelper.CurrentTimeZone.Id) });

            //model.DisplayVatNumber = _taxSettings.EuVatEnabled;
            ////form fields
            //model.GenderEnabled = _customerSettings.GenderEnabled;
            //model.DateOfBirthEnabled = _customerSettings.DateOfBirthEnabled;
            //model.DateOfBirthRequired = _customerSettings.DateOfBirthRequired;
            //model.CompanyEnabled = _customerSettings.CompanyEnabled;
            //model.CompanyRequired = _customerSettings.CompanyRequired;
            //model.StreetAddressEnabled = _customerSettings.StreetAddressEnabled;
            //model.StreetAddressRequired = _customerSettings.StreetAddressRequired;
            //model.StreetAddress2Enabled = _customerSettings.StreetAddress2Enabled;
            //model.StreetAddress2Required = _customerSettings.StreetAddress2Required;
            //model.ZipPostalCodeEnabled = _customerSettings.ZipPostalCodeEnabled;
            //model.ZipPostalCodeRequired = _customerSettings.ZipPostalCodeRequired;
            //model.CityEnabled = _customerSettings.CityEnabled;
            //model.CityRequired = _customerSettings.CityRequired;
            //model.CountryEnabled = _customerSettings.CountryEnabled;
            //model.CountryRequired = _customerSettings.CountryRequired;
            //model.StateProvinceEnabled = _customerSettings.StateProvinceEnabled;
            //model.StateProvinceRequired = _customerSettings.StateProvinceRequired;
            //model.PhoneEnabled = _customerSettings.PhoneEnabled;
            //model.PhoneRequired = _customerSettings.PhoneRequired;
            //model.FaxEnabled = _customerSettings.FaxEnabled;
            //model.FaxRequired = _customerSettings.FaxRequired;
            //model.NewsletterEnabled = _customerSettings.NewsletterEnabled;
            //model.AcceptPrivacyPolicyEnabled = _customerSettings.AcceptPrivacyPolicyEnabled;
            //model.UsernamesEnabled = _customerSettings.UsernamesEnabled;
            //model.CheckUsernameAvailabilityEnabled = _customerSettings.CheckUsernameAvailabilityEnabled;
            //model.HoneypotEnabled = _securitySettings.HoneypotEnabled;
            //model.DisplayCaptcha = _captchaSettings.Enabled && _captchaSettings.ShowOnRegistrationPage;

            ////countries and states
            //if (_customerSettings.CountryEnabled)
            //{
            //    model.AvailableCountries.Add(new SelectListItem { Text = _localizationService.GetResource("Address.SelectCountry"), Value = "0" });

            //    foreach (var c in _countryService.GetAllCountries(_workContext.WorkingLanguage.Id))
            //    {
            //        model.AvailableCountries.Add(new SelectListItem
            //        {
            //            Text = c.GetLocalized(x => x.Name),
            //            Value = c.Id.ToString(),
            //            Selected = c.Id == model.CountryId
            //        });
            //    }

            //    if (_customerSettings.StateProvinceEnabled)
            //    {
            //        //states
            //        var states = _stateProvinceService.GetStateProvincesByCountryId(model.CountryId, _workContext.WorkingLanguage.Id).ToList();
            //        if (states.Count > 0)
            //        {
            //            model.AvailableStates.Add(new SelectListItem { Text = _localizationService.GetResource("Address.SelectState"), Value = "0" });

            //            foreach (var s in states)
            //            {
            //                model.AvailableStates.Add(new SelectListItem { Text = s.GetLocalized(x => x.Name), Value = s.Id.ToString(), Selected = (s.Id == model.StateProvinceId) });
            //            }
            //        }
            //        else
            //        {
            //            bool anyCountrySelected = model.AvailableCountries.Any(x => x.Selected);

            //            model.AvailableStates.Add(new SelectListItem
            //            {
            //                Text = _localizationService.GetResource(anyCountrySelected ? "Address.OtherNonUS" : "Address.SelectState"), 
            //                Value = "0"
            //            });
            //        }

            //    }

            //custom customer attributes
            //var customAttributes = PrepareCustomCustomerAttributes(_workContext.CurrentCustomer, overrideCustomCustomerAttributesXml);
            //customAttributes.ForEach(model.CustomerAttributes.Add);
        }
        #endregion
    }
}