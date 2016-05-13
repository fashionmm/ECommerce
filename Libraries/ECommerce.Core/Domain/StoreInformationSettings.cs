using ECommerce.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain
{
    public class StoreInformationSettings:ISettings
    {
        /// <summary>
        /// 获取或设置一个值，指示是否 显示“powered by nopCommerce”文本。
        /// 请找到更多的信息在http://www.nopcommerce.com/copyrightremoval.aspx。
        /// </summary>
        public bool HidePoweredByNopCommerce { get; set; }

        /// <summary>
        /// 获取或设置一个值，表示店铺是否被关闭。
        /// </summary>
        public bool StoreClosed { get; set; }

        /// <summary>
        /// 获取或设置默认店铺主题
        /// </summary>
        public string DefaultStoreTheme { get; set; }

        /// <summary>
        /// 获取或设置一个值，表示是否允许顾客选择主题。
        /// </summary>
        public bool AllowCustomerToSelectTheme { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否在公共店铺中显示小型探查器（用于调试）
        /// </summary>
        public bool DisplayMiniProfilerInPublicStore { get; set; }

        /// <summary>
        /// 获取或设置一个值，指示是否应显示有关欧盟新的cookie法律警告
        /// </summary>
        public bool DisplayEuCookieLawWarning { get; set; }

        /// <summary>
        /// 获取或设置Facebook网址。 
        /// </summary>
        public string FacebookLink { get; set; }

        /// <summary>
        /// 获取或设置Twitter网址。 
        /// </summary>
        public string TwitterLink { get; set; }

        /// <summary>
        /// 获取或设置YouTube网址。
        /// </summary>
        public string YoutubeLink { get; set; }

        /// <summary>
        /// 获取或设置Google+网址。 
        /// </summary>
        public string GooglePlusLink { get; set; }
    }
}
