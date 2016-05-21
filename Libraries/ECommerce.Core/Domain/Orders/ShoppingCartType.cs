using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Orders
{
   public enum ShoppingCartType
    {
       /// <summary>
       /// 购物车
       /// </summary>
       ShoppingCart=1,
       /// <summary>
       /// 购物清单
       /// </summary>
       Wishlist=2
    }
}
