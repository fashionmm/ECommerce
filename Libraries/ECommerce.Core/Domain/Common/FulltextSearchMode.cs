using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Core.Domain.Common
{
    /// <summary>
    /// 
    /// </summary>
    public enum FulltextSearchMode
    {
        //精确匹配
        ExactMatch=0,
        //包含
        Or=5,
        //
        And=10
    }
}
