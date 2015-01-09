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
using System.Collections.ObjectModel;

using MaxLabs.bbsMax.Enums;
using MaxLabs.bbsMax.DataAccess;

namespace MaxLabs.bbsMax.Entities
{
	public class ClubMember : IFillSimpleUser
	{
		public ClubMember(DataReaderWrap reader)
		{
			ClubID = reader.Get<int>("ClubID");
			UserID = reader.Get<int>("UserID");

			Status = reader.Get<ClubMemberStatus>("Status");

			CreateDate = reader.Get<DateTime>("CreateDate");

		}

		public int ClubID { get; set; }
		public int UserID { get; set; }

		public ClubMemberStatus Status { get; set; }

		public DateTime CreateDate { get; set; }

		public SimpleUser User { get { return UserBO.Instance.GetFilledSimpleUser(this.UserID); } }

		#region IFillSimpleUser 成员

		public int GetUserIDForFill()
		{
			return this.UserID;
		}

		#endregion
	}

	public class ClubMemberCollection : Collection<ClubMember>
	{
		public ClubMemberCollection()
		{
		}

		public ClubMemberCollection(DataReaderWrap reader)
		{
			while (reader.Next)
			{
				this.Add(new ClubMember(reader));
			}
		}

		public int TotalRecords { get; set; }
	}
}