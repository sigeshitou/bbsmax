﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Collections.Generic;
using System.Text;

namespace MaxLabs.bbsMax.Filters
{
    public class ChatSessionFilter:FilterBase<ChatSessionFilter>
    {
        public ChatSessionFilter() {
            this.PageSize = Consts.DefaultPageSize;
        }

        [FilterItem(FormName = "userid")]
        public int? UserID
        {
            get;
            set;
        }

        [FilterItem( FormName="username" )]
        public string Username
        {
            get;
            set;
        }

        //[FilterItem(FormName = "targetusername")]
        //public string TargetUsername
        //{
        //    get;
        //    set;
        //}

        [FilterItem(FormName = "beginDate", FormType=FilterItemFormType.BeginDate)]
        public DateTime? BeginDate { get; set; }

        [FilterItem(FormName = "enddate", FormType = FilterItemFormType.EndDate)]
        public DateTime? EndDate { get; set; }

        [FilterItem(FormName="Contains")]
        public string Contains { get; set; }

        public bool ShowAll { get; set; }

        [FilterItem(FormName="isdesc")]
        public bool IsDesc { get; set; }

        [FilterItem(FormName="pagesize")]
        public int PageSize { get; set; }
    }
}