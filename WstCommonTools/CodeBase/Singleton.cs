using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstCommonTools
{
    /// <summary>
    /// 泛型单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonTemplate<T> where T : class, new()
    {
        private static T m_instance;                        //静态对象
        private static readonly object syslock;             //静态锁

        static SingletonTemplate()                          //静态构造函数
        {
            SingletonTemplate<T>.syslock = new object();    //静态锁
        }

        public static T GetInstance()                       //获取单例对象函数
        {
            if (SingletonTemplate<T>.m_instance == null)    //判断对象是否为null
            {
                object syslock = SingletonTemplate<T>.syslock;
                lock (syslock)                              //加锁
                {
                    if (SingletonTemplate<T>.m_instance == null)
                    {
                        SingletonTemplate<T>.m_instance = Activator.CreateInstance<T>();
                    }
                }
            }
            return SingletonTemplate<T>.m_instance;         //返回对象
        }
    }
}
