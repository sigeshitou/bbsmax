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

namespace MaxLabs.bbsMax.Logs
{
	[OperationType(Topic_DeleteTopicByIDs.TYPE_NAME)]
	public class Topic_DeleteTopicByIDs : Operation
	{
        public const string TYPE_NAME = "删除帖子";

        public Topic_DeleteTopicByIDs(int operatorID, string operatorName, int forumID, string operatorIP, List<int> topicIDs)
            : base(operatorID, operatorName, operatorIP, 0, 0, forumID)
        {
            TopicIDs = topicIDs;
        }

        public override string TypeName
        {
            get { return TYPE_NAME; }
        }

        public List<int> TopicIDs
		{
			get;
			private set;
		}

		public override string Message
		{
			get
			{

				return string.Format(
					"<a href=\"{0}\">{1}</a> 使用多选删除功能，删除了ID为：{2} 的主题"
					, BbsRouter.GetUrl("space/" + OperatorID)
					, OperatorName
                    , StringUtil.Join(TopicIDs, ",")
				);
			}
		}
	}
}