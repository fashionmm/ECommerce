using System;
using System.Linq;
using ECommerce.Core.Domain.Common;

namespace ECommerce.Core.Domain.Customers
{
    public static class CustomerExtensions
    {
        #region Customer role

        /// <summary>
        /// ��ȡһ��ֵ��ָʾ�Ƿ���ĳ���ͻ��ͻ���ɫ��
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="customerRoleSystemName">Customer role system name</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsInCustomerRole(this Customer customer,
            string customerRoleSystemName, bool onlyActiveCustomerRoles = true)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (String.IsNullOrEmpty(customerRoleSystemName))
                throw new ArgumentNullException("customerRoleSystemName");

            var result = customer.CustomerRoles
                .FirstOrDefault(cr => (!onlyActiveCustomerRoles || cr.Active) && (cr.SystemName == customerRoleSystemName)) != null;
            return result;
        }

        /// <summary>
        /// ��ȡһ��ֵ��ָʾ�ǿͻ���������
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Result</returns>
        public static bool IsSearchEngineAccount(this Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (!customer.IsSystemAccount || String.IsNullOrEmpty(customer.SystemName))
                return false;

            var result = customer.SystemName.Equals(SystemCustomerNames.SearchEngine, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�û��Ƿ�Ϊ��̨��������ü�¼
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Result</returns>
        public static bool IsBackgroundTaskAccount(this Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (!customer.IsSystemAccount || String.IsNullOrEmpty(customer.SystemName))
                return false;

            var result = customer.SystemName.Equals(SystemCustomerNames.BackgroundTask, StringComparison.InvariantCultureIgnoreCase);
            return result;
        }

        /// <summary>
        /// ��ȡһ��ֵ��ָʾ�Ƿ�ͻ�����Ա
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsAdmin(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Administrators, onlyActiveCustomerRoles);
        }

        /// <summary>
        ///��ȡһ��ֵ��ָʾ�ͻ�����̳����
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsForumModerator(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.ForumModerators, onlyActiveCustomerRoles);
        }

        /// <summary>
        ///��ȡһ��ֵ��˵���ͻ��Ƿ���ע��
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsRegistered(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Registered, onlyActiveCustomerRoles);
        }

        /// <summary>
        ///��ȡһ��ֵ��ָʾ�ͻ�������
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsGuest(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Guests, onlyActiveCustomerRoles);
        }

        /// <summary>
        /// Gets a value indicating whether customer is vendor
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="onlyActiveCustomerRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsVendor(this Customer customer, bool onlyActiveCustomerRoles = true)
        {
            return IsInCustomerRole(customer, SystemCustomerRoleNames.Vendors, onlyActiveCustomerRoles);
        }
        #endregion

        #region Addresses

        public static void RemoveAddress(this Customer customer, Address address)
        {
            if (customer.Addresses.Contains(address))
            {
                if (customer.BillingAddress == address) customer.BillingAddress = null;
                if (customer.ShippingAddress == address) customer.ShippingAddress = null;

                customer.Addresses.Remove(address);
            }
        }

        #endregion
    }
}
