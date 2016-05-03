using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Core.Domain.Stores
{
    public static class StoreExtensions
    {
        /// <summary>
        /// 解析逗号分隔的宿主
        /// </summary>
        /// <param name="store">商店</param>
        /// <returns>逗号分隔的宿主</returns>
        public static string[] ParseHostValues(this Store store)
        {
            if (store == null)
                throw new ArgumentNullException("store");

            var parsedValues = new List<string>();
            if (!String.IsNullOrEmpty(store.Hosts))
            {
                string[] hosts = store.Hosts.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string host in hosts)
                {
                    var tmp = host.Trim();
                    if (!String.IsNullOrEmpty(tmp))
                        parsedValues.Add(tmp);
                }
            }
            return parsedValues.ToArray();
        }

        /// <summary>
        /// 指示商店是否包含指定宿主
        /// </summary>
        /// <param name="store">商店</param>
        /// <param name="host">Host</param>
        /// <returns>true - 包含, false - 不包含</returns>
        public static bool ContainsHostValue(this Store store, string host)
        {
            if (store == null)
                throw new ArgumentNullException("store");

            if (String.IsNullOrEmpty(host))
                return false;

            var contains = store.ParseHostValues()
                                .FirstOrDefault(x => x.Equals(host, StringComparison.InvariantCultureIgnoreCase)) != null;
            return contains;
        }
    }
}
