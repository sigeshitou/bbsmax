﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using MaxLabs.bbsMax.Entities;

namespace MaxLabs.bbsMax.XCmd
{
    public class ResetFeedCommentInfoCmd : IXCmd
    {

        #region ICmdHandler 成员

        public string Command
        {
            get { return "ResetFeedCommentInfo"; }
        }

        public void Process(DataTable data)
        {

            FeedCollection feeds = FeedBO.Instance.GetAllCachedFeed();
            if (feeds == null || feeds.Count == 0)
                return;
            foreach (DataRow row in data.Rows)
            {
                int feedID = (int)row["FeedID"];

                Feed feed = feeds.GetValue(feedID);
                if (feed != null)
                {
                    feed.CommentInfo = row["CommentInfo"].ToString();
                }
            }
		}

        #endregion
    }
}