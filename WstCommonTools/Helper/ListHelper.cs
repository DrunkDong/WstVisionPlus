using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstCommonTools
{
    public static class ListHelper
    {
        /// <summary>
        /// List列表元素交换位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">数组名</param>
        /// <param name="indexA">索引A</param>
        /// <param name="indexB">索引B</param>
        public static void Swap<T>(List<T> list, int indexA, int indexB)
        {
            // 确保索引在范围内
            if (indexA >= 0 && indexB >= 0 && indexA < list.Count && indexB < list.Count)
            {
                T temp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = temp;
            }
        }
    }
}
