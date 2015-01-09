﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Text;
using System.Collections.Generic;

namespace MaxLabs.bbsMax.Enums
{
	/// <summary>
	/// 
	/// </summary>
    public enum LevelStatus
	{
        /// <summary>
        /// 当前等级以及等级之上
        /// </summary>
        Above = 0,

        /// <summary>
        /// 当前等级
        /// </summary>
        Currently = 1,

        /// <summary>
        /// 当前等级以及等级之下
        /// </summary>
        Below = 2
	}
}