﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECommerce.Web.Framework.Themes
{
    public class ThemeableRazorViewEngine : ThemeableVirtualPathProviderViewEngine
    {
        public ThemeableRazorViewEngine()
        {
            AreaViewLocationFormats = new[]
                                          {
                                              //themes
                                              "~/Areas/{2}/Themes/{3}/Views/{1}/{0}.cshtml",
                                              "~/Areas/{2}/Themes/{3}/Views/Shared/{0}.cshtml",
                                              
                                              //default
                                              "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                              "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                          };

            AreaMasterLocationFormats = new[]
                                            {
                                                //themes
                                                "~/Areas/{2}/Themes/{3}/Views/{1}/{0}.cshtml",
                                                "~/Areas/{2}/Themes/{3}/Views/Shared/{0}.cshtml",


                                                //default
                                                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                            };

            AreaPartialViewLocationFormats = new[]
                                                 {
                                                     //themes
                                                    "~/Areas/{2}/Themes/{3}/Views/{1}/{0}.cshtml",
                                                    "~/Areas/{2}/Themes/{3}/Views/Shared/{0}.cshtml",
                                                    
                                                    //default
                                                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                    "~/Areas/{2}/Views/Shared/{0}.cshtml"
                                                 };

            ViewLocationFormats = new[]
                                      {
                                            //themes
                                            "~/Themes/{2}/Views/{1}/{0}.cshtml", 
                                            "~/Themes/{2}/Views/Shared/{0}.cshtml",

                                            //default
                                            "~/Views/{1}/{0}.cshtml", 
                                            "~/Views/Shared/{0}.cshtml",

                                            //Admin
                                            "~/Administration/Views/{1}/{0}.cshtml",
                                            "~/Administration/Views/Shared/{0}.cshtml",
                                      };

            MasterLocationFormats = new[]
                                        {
                                            //themes
                                            "~/Themes/{2}/Views/{1}/{0}.cshtml", 
                                            "~/Themes/{2}/Views/Shared/{0}.cshtml", 

                                            //default
                                            "~/Views/{1}/{0}.cshtml", 
                                            "~/Views/Shared/{0}.cshtml"
                                        };

            PartialViewLocationFormats = new[]
                                             {
                                                 //themes
                                                "~/Themes/{2}/Views/{1}/{0}.cshtml",
                                                "~/Themes/{2}/Views/Shared/{0}.cshtml",

                                                //default
                                                "~/Views/{1}/{0}.cshtml", 
                                                "~/Views/Shared/{0}.cshtml", 

                                                //Admin
                                                "~/Administration/Views/{1}/{0}.cshtml",
                                                "~/Administration/Views/Shared/{0}.cshtml",
                                             };

            FileExtensions = new[] { "cshtml" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            IEnumerable<string> fileExtensions = base.FileExtensions;
            return new RazorView(controllerContext, partialPath, null, false, fileExtensions);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            IEnumerable<string> fileExtensions = base.FileExtensions;
            return new RazorView(controllerContext, viewPath, masterPath, true, fileExtensions);

        }
    }
}
