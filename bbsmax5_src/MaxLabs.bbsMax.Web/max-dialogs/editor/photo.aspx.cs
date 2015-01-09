﻿//
// 请注意：bbsmax 不是一个免费产品，源代码仅限用于学习，禁止用于商业站点或者其他商业用途
// 如果您要将bbsmax用于商业用途，需要从官方购买商业授权，得到授权后可以基于源代码二次开发
//
// 版权所有 厦门麦斯网络科技有限公司
// 公司网站 www.bbsmax.com
//

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using MaxLabs.WebEngine;
using MaxLabs.bbsMax.Entities;

namespace MaxLabs.bbsMax.Web.max_dialogs
{
    public partial class photo : EditorAttachPageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			m_AlbumList = AlbumBO.Instance.GetUserAlbums(MyUserID);

			if (m_AlbumList.Count > 0)
			{
				m_AlbumID = _Request.Get<int>("album", Method.Get, m_AlbumList[0].AlbumID);

				int page = _Request.Get<int>("page", Method.Get, 1);

				m_PhotoList = AlbumBO.Instance.GetPhotos(m_AlbumID, page, 12);

				m_PhotoTotalCount = m_PhotoList.TotalRecords;

				m_Album = m_AlbumList.GetValue(m_AlbumID);

                int tab = _Request.Get<int>("tab", Method.Get, 0);

                SetPager("list", string.Format("?id={0}&tab={2}&page={1}&forumid={3}&album={4}", _Request.Get("id", Method.Get, string.Empty), "{0}", TabState, _Request.Get<int>("forumid", Method.Get, 0), m_AlbumID), page, 12, m_PhotoTotalCount);
			}
		}

        protected int TabState
        {
            get
            {
                return _Request.Get<int>("tab", Method.Get, 0);
            }
        }

		private int m_AlbumID;

		public int AlbumID
		{
			get { return m_AlbumID; }
		}

		private Album m_Album;

		public Album Album
		{
			get { return m_Album; }
		}

		private AlbumCollection m_AlbumList;

		public AlbumCollection AlbumList
		{
			get { return m_AlbumList; }
		}

		private PhotoCollection m_PhotoList;

		public PhotoCollection PhotoList
		{
			get { return m_PhotoList; }
		}

		private int m_PhotoTotalCount;

		public int PhotoTotalCount
		{
			get { return m_PhotoTotalCount; }
		}

        protected override ExtensionList ListFileTypes
        {
            get
            {

                if (m_ListFileTypes == null)
                {
                    m_ListFileTypes = FilterFileType(ImageFileTypes);
                }
                return m_ListFileTypes;
            }
        }

        protected override string TypeName
        {
            get
            {
                return "图片";
            }
        }
	}
}