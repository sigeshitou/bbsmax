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
using System.Collections.Specialized;
using MaxLabs.bbsMax.Entities;

namespace MaxLabs.bbsMax.Settings
{
    
    public class PermissionSetWithNodeCollection<T> : HashedCollectionBase<int, T> where T : IPermissionSet, ICloneable, IPrimaryKey<int>, new()
    {
        private object m_CacheLocker = new object();
        private Dictionary<int, T> m_Cached = new Dictionary<int, T>();

        public override void Clear()
        {
            lock (m_CacheLocker)
            {
                m_Cached.Clear();
                base.Clear();
            }
        }

        public T GetPermission(int nodeID)
        {
            T set;
            if (m_Cached.TryGetValue(nodeID, out set))
                return set;

            return GetPermission(true, nodeID, nodeID, new T().NodeItemList);
        }

        private T GetPermission(bool isFirst, int nodeID, int realNodeID, NodeItemCollection nodes)
        {
            T set;

            if (isFirst == false)
            {
                if (m_Cached.TryGetValue(realNodeID, out set))
                    return set;
            }
            if(true == this.TryGetValue(nodeID,out set))
            {
                if (set.NodeID != realNodeID)
                {
                    T clone = (T)set.Clone();

                    clone.RealNodeID = realNodeID;

                    if (false == m_Cached.ContainsKey(realNodeID))
                    {
                        lock (m_Cached)
                        {
                            if (false == m_Cached.ContainsKey(realNodeID))
                            {
                                m_Cached.Add(realNodeID, clone);
                            }
                        }
                    }
                    return clone;
                }
                return set;
            }


            if (nodeID != 0)
            {
                NodeItem nodeItem = nodes.GetValue(nodeID);
                if (nodeItem != null)
                {
                    T t = GetPermission(false, nodeItem.ParentID, realNodeID, nodes);
                    return t;
                }
            }


            if (nodeID == 0)
            {
                T t = new T();
                t.RealNodeID = realNodeID;
                return t;
            }

            return default(T);
        }

        public override void Add(T item)
        {
            if (item.NodeID == 0)
            {
                if (this.Count > 0 && this[0].NodeID == 0)
                    this[0] = item;
                else
                    this.Insert(0, item);
            }
            else
                base.Add(item);
        }

    }
}