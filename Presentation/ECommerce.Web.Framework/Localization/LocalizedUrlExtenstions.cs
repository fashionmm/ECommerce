﻿using System;
using ECommerce.Core.Domain.Localization;

namespace ECommerce.Web.Framework.Localization
{

    public static class LocalizedUrlExtenstions
    {
        private static int _seoCodeLength = 2;
        
        /// <summary>
        /// Returns a value indicating whether ECommerce is run in virtual directory
        /// </summary>
        /// <param name="applicationPath">Application path</param>
        /// <returns>Result</returns>
        private static bool IsVirtualDirectory(this string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            return applicationPath != "/";
        }

        /// <summary>
        /// 从原始URL删除应用程序路径
        /// </summary>
        /// <param name="rawUrl">原始URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <returns>Result</returns>
        public static string RemoveApplicationPathFromRawUrl(this string rawUrl, string applicationPath)
        {
            if (string.IsNullOrEmpty(applicationPath))
                throw new ArgumentException("Application path is not specified");

            if (rawUrl.Length == applicationPath.Length)
                return "/";

            
            var result = rawUrl.Substring(applicationPath.Length);
            //raw url always starts with '/'
            if (!result.StartsWith("/"))
                result = "/" + result;
            return result;
        }

        /// <summary>
        /// Get language SEO code from URL
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <param name="isRawPath">A value indicating whether war URL is passed</param>
        /// <returns>Result</returns>
        public static string GetLanguageSeoCodeFromUrl(this string url, string applicationPath, bool isRawPath)
        {
            if (isRawPath)
            {
                if (applicationPath.IsVirtualDirectory())
                {
                    //we're in virtual directory. So remove its path
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);
                }

                return url.Substring(1, _seoCodeLength);
            }
            
            return url.Substring(2, _seoCodeLength);
        }

        /// <summary>
        /// 获取一个值指示是否URL定位（包含搜索引擎优化代码）
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="applicationPath">应用程序路径</param>
        /// <param name="isRawPath">A value indicating whether war URL is passed</param>
        /// <returns>Result</returns>
        public static bool IsLocalizedUrl(this string url, string applicationPath, bool isRawPath)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            if (isRawPath)
            {
                if (applicationPath.IsVirtualDirectory())
                {
                    //在虚拟目录中，删除它的路径
                    url = url.RemoveApplicationPathFromRawUrl(applicationPath);
                }

                int length = url.Length;
                //too short url
                if (length < 1 + _seoCodeLength)
                    return false;

                //url like "/en"
                if (length == 1 + _seoCodeLength)
                    return true;

                //urls like "/en/" or "/en/somethingelse"
                return (length > 1 + _seoCodeLength) && (url[1 + _seoCodeLength] == '/');
            }
            else
            {
                int length = url.Length;
                //too short url
                if (length < 2 + _seoCodeLength)
                    return false;

                //url like "/en"
                if (length == 2 + _seoCodeLength)
                    return true;

                //urls like "/en/" or "/en/somethingelse"
                return (length > 2 + _seoCodeLength) && (url[2 + _seoCodeLength] == '/');
            }
        }

        /// <summary>
        /// Remove language SEO code from URL
        /// </summary>
        /// <param name="url">Raw URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <returns>Result</returns>
        public static string RemoveLanguageSeoCodeFromRawUrl(this string url, string applicationPath)
        {
            if (string.IsNullOrEmpty(url))
                return url;

            string result = null;
            if (applicationPath.IsVirtualDirectory())
            {
                //we're in virtual directory. So remove its path
                url = url.RemoveApplicationPathFromRawUrl(applicationPath);
            }

            int length = url.Length;
            if (length < _seoCodeLength + 1)    //too short url
                result = url;
            else if (length == 1 + _seoCodeLength)  //url like "/en"
                result = url.Substring(0, 1);
            else
                result = url.Substring(_seoCodeLength + 1); //urls like "/en/" or "/en/somethingelse"

            if (applicationPath.IsVirtualDirectory())
                result = applicationPath + result;  //add back applciation path
            return result;
        }

        /// <summary>
        /// Add language SEO code from URL
        /// </summary>
        /// <param name="url">Raw URL</param>
        /// <param name="applicationPath">Application path</param>
        /// <param name="language">Language</param>
        /// <returns>Result</returns>
        public static string AddLanguageSeoCodeToRawUrl(this string url, string applicationPath,
            Language language)
        {
            if (language == null)
                throw new ArgumentNullException("language");

            //null validation is not required
            //if (string.IsNullOrEmpty(url))
            //    return url;


            int startIndex = 0;
            if (applicationPath.IsVirtualDirectory())
            {
                //we're in virtual directory.
                startIndex = applicationPath.Length;
            }

            //add SEO code
            url = url.Insert(startIndex, language.UniqueSeoCode);
            url = url.Insert(startIndex, "/");

            return url;
        }
    }
}