using MyIOC.AttributeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace MyIOC.IOC
{
    /// <summary>
    /// Undo
    /// 1. 没有实现域和生命周期
    /// 2. 容器选择问题
    /// </summary>
    public class IOCFactory
    {
        /// <summary>
        /// IOC容器，创建的对象的容器
        /// string：key：对象类型名
        /// object value：对象实例
        /// </summary>
        private Dictionary<string, object> iocDictionaries = new Dictionary<string, object>();
        /// <summary>
        /// IOC中对象类型的容器
        /// string key ：类型名
        /// Type value:类型
        /// </summary>
        private Dictionary<string,Type> iocTypeDictionaries = new Dictionary<string,Type>();    
        //加载程序集，将会有我门自定义的特性标签的类的类型存储到类型容器中
        public void LoadAssmaly(string asmName)
        {
            Assembly assembly = Assembly.Load(asmName);
            //注意这里获取的是程序集中所有定义的类型
            Type[] types = assembly.GetTypes();
            //筛选出含有IOCServerAttribute特性标签的类，存储其type类型
            foreach(Type type in types)
            {
                IOCServerAttribute iocService = type.GetCustomAttribute<IOCServerAttribute>();
                //如果这个类是IOCServiceAttribute的标注类，则把其类存储到类型容器中
                if (iocService != null)
                {
                    iocTypeDictionaries.Add(type.Name, type);//将最终的数据进行保存
                }
            }

        }

        public object GetObject(string typeNmae)
        {
            //根据参数取出指定的type
            Type type = iocTypeDictionaries[typeNmae];

            //创建type类型的对象
            object objectValue = Activator.CreateInstance(type);

            //获取type类型对象的所有属性

            PropertyInfo[] propertyInfos = type.GetProperties();
            //便利这个类的的所有属性，查找是否包含IocInjectAttribute类型的特性
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                IOCInjectAttribute iOCInject = propertyInfo.GetCustomAttribute<IOCInjectAttribute>();
                
                if(iOCInject != null)
                {
                    //保存这个属性的type类型
                    Type propertyType = propertyInfo.PropertyType;
                    //为propertyinfo属性赋值
                    //接着使用递归的方式创建一个执行类型的实例
                    propertyInfo.SetValue(objectValue, GetObject(propertyInfo.PropertyType.Name));                    
                }

            }
            //将创建的对象存储到容器中
            iocDictionaries.Add(typeNmae, objectValue);
            return objectValue;
        }

    }
}
