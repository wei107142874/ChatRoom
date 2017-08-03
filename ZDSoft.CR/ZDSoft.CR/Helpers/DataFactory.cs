//************************************************************************//
using System;
using System.Reflection;
using System.Configuration;

namespace ZDSoft.CR.Web
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入
    /// <appSettings> 
    /// <add key="DAL" value="LYH.DAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataFactory
    {
        //程序集名称
        private static readonly string _AssemblyPath = "ZDSoft.CR.Component";

        /// <summary>
        /// 根据接口创建对象
        /// </summary>
        public static T CreateObject<T>()
        {
            string calssName = typeof(T).FullName;
            calssName = calssName.Substring(calssName.LastIndexOf(".") + 2);//获取服务名称
            calssName = calssName.Replace("Service", "");//获取对象名称
            return (T)Assembly.Load(_AssemblyPath).CreateInstance(string.Format("{0}.{1}Component", _AssemblyPath,calssName));//反射创建
        }


    }
}


