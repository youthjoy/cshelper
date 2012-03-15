using System;
using System.Collections.Generic;
using System.Text;

namespace QX.GenFramework.Helper
{
    public class CollectionHelper
    {
        /// <summary>
        /// 查找所有满足条件的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static List<T> Filter<T>(List<T> list, Predicate<T> match)
        {
            List<T> result = new List<T>();
            result = list.FindAll(match);
            return result;
        }

        /// <summary>
        /// 查找满足条件的一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static T Filter<T>(List<T> list, Predicate<T> match,int start,int count)
        {
            return list.Find(match);    
        }
    }
}
