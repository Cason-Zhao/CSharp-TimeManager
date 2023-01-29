using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Business.Util
{
    public static class EnumExtension
    {
        public static ConcurrentDictionary<Enum, string> _Names = new ConcurrentDictionary<Enum, string>();
        public static ConcurrentDictionary<Type, Dictionary<Enum, string>> _Lists = new ConcurrentDictionary<Type, Dictionary<Enum, string>>();

        /// <summary>
        /// 获取枚举的Description特性的值
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum @enum)
        {
            if (@enum == null)
            {
                return null;
            }

            // 加入缓存
            if (!_Names.ContainsKey(@enum))
            {
                var type = @enum.GetType();
                var enumName = Enum.GetName(type, @enum);

                var attrs = type.GetField(enumName)
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs == null || attrs.Length == 0)
                {
                    return null;
                }

                _Names.TryAdd(@enum, ((DescriptionAttribute[])attrs)[0].Description);
            }
            return _Names[@enum];
        }

        /// <summary>
        /// 获取枚举的Description特性的值
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescription2(this Enum @enum)
        {
            if (@enum == null)
            {
                return null;
            }

            //var type = @enum.GetType();
            //var enumName = Enum.GetName(type, @enum);

            //var attrs = type.GetField(enumName)
            //    .GetCustomAttributes(typeof(DescriptionAttribute), false);
            //if (attrs == null || attrs.Length == 0)
            //{
            //    return null;
            //}

            //return ((DescriptionAttribute[])attrs)[0].Description;

            var attrs = @enum.GetAttributeValues<DescriptionAttribute>();
            if (attrs == null || attrs.Length == 0)
            {
                return null;
            }

            return attrs[0].Description;
        }

        /// <summary>
        /// 获取枚举的指定特性的列表
        /// </summary>
        /// <typeparam name="T">指定的特性的类型</typeparam>
        /// <param name="enum">枚举值</param>
        /// <param name="attributeTypeInherit">特性类型是否继承（即：是否获取T类型的子类型）</param>
        /// <returns></returns>
        public static T[] GetAttributeValues<T>(this Enum @enum, bool attributeTypeInherit = true) where T : Attribute
        {
            if (@enum == null)
            {
                return null;
            }

            var type = @enum.GetType();
            var enumName = Enum.GetName(type, @enum);

            var attrs = type.GetField(enumName).GetCustomAttributes(typeof(T), attributeTypeInherit);
            if (attrs == null || attrs.Length == 0)
            {
                return null;
            }

            return (T[])attrs;
        }

        /// <summary>
        /// 获取枚举值与描述值的键值列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attributeTypeInherit"></param>
        /// <returns></returns>
        public static List<KeyValuePair<T, string>> GetDescriptionList<T>(bool attributeTypeInherit = true) where T : Enum
        {
            var result = (from p in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                          let attr = (DescriptionAttribute)(p.GetCustomAttributes(typeof(DescriptionAttribute), attributeTypeInherit)
                              .FirstOrDefault())
                          where attr != null
                          select new { Key = (T)p.GetValue(null), Value = attr.Description })
                         .ToDictionary(p => p.Key, p => p.Value);
            result.ToList().ForEach(data =>
            {
                if (!_Names.ContainsKey(data.Key))
                {
                    _Names.TryAdd(data.Key, data.Value);
                }
            });

            return result.ToList();
        }
    }
}
