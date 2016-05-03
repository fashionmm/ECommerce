using ECommerce.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ECommerce.Core.Domain.Common
{
    public partial class Address
    {
        /// <summary>
        /// 获取或设置第一个名字
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 获取或设置最后名称
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 获取或设置email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置公司名
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 获取或设置该国家标识符
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// 获取或设置州/省标识
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// 获取或设置城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 获取或设置地址1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// 获取或设置地址2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// 获取或设置邮政编码
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// 获取或设置电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 获取或设置传真号码
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 获取或设置自定义属性 (see "AddressAttribute" entity for more info)
        /// </summary>
        public string CustomAttributes { get; set; }

        /// <summary>
        /// 获取或设置实例创建的日期和时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 获取或设置国家
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// 获取或设置该州/省
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }


        public object Clone()
        {
            var addr = new Address
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Company = this.Company,
                Country = this.Country,
                CountryId = this.CountryId,
                StateProvince = this.StateProvince,
                StateProvinceId = this.StateProvinceId,
                City = this.City,
                Address1 = this.Address1,
                Address2 = this.Address2,
                ZipPostalCode = this.ZipPostalCode,
                PhoneNumber = this.PhoneNumber,
                FaxNumber = this.FaxNumber,
                CustomAttributes = this.CustomAttributes,
                CreatedOnUtc = this.CreatedOnUtc,
            };
            return addr;
        }

    }
}
