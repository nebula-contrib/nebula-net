using Nebula.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NebulaNet
{
    internal static class ValueMappingExtensions
    {
        internal static object Mapping(this @Value value, Type targetType)
        {
            Type mapType = null;
            switch (targetType.Name)
            {
                case "Bool":
                    return value.BVal;
                case "Int64":
                    return value.IVal;
                case "Double":
                    return value.FVal;
                case "String":
                    return Encoding.UTF8.GetString(value.SVal);
                case "Nebula.Common.Date":
                    return value.DVal;
                case "Nebula.Common.Time":
                    return value.TVal;
                case "DateTime":
                    return value.DtVal;
                case "Vertex":
                    return new NotImplementedException(); //value.VVal;
                case "Edge":
                    return new NotImplementedException(); // value.EVal;
                case "Path":
                    return new NotImplementedException(); // value.PVal;
                case "Dictionary":
                    return new NotImplementedException(); //value.MVal;
                case "HashSet":
                    return new NotImplementedException(); //value.UVal;
                case "DataSet":
                    return new NotImplementedException(); //value.GVal;
                case "Geography":
                    return new NotImplementedException(); //value.GgVal;
                case "Duration":
                    return new NotImplementedException(); //value.DuVal;
                case "List`1"://List<T>
                    mapType = targetType.GetGenericArguments()[0];
                    if (mapType.Name== "Int64")
                    {
                        return value.LVal.Values.Select(x => x.Mapping(mapType)).Cast<long>().ToList();
                    }
                    if (mapType.Name == "String")
                    {
                        return value.LVal.Values.Select(x => x.Mapping(mapType)).Cast<string>().ToList();
                    }
                    return new TypeLoadException();
                default:
                    if (targetType.IsArray)//数组
                    {
                        mapType = targetType.GetElementType();
                        if (mapType.Name == "Int64")
                        {
                            return value.LVal.Values.Select(x => x.Mapping(mapType)).Cast<long>().ToArray();
                        }
                        if (mapType.Name == "String")
                        {
                            return value.LVal.Values.Select(x => x.Mapping(mapType)).Cast<string>().ToArray();
                        }
                        return new TypeLoadException();
                    }
                    return new TypeLoadException();
            }
        }

        /// <summary>
        /// 将一个对象转换为指定类型
        /// </summary>
        /// <param name="obj">待转换的对象</param>
        /// <param name="type">目标类型</param>
        /// <returns>转换后的对象</returns>
        private static object ConvertToObject(object obj, Type type)
        {
            if (type == null) return obj;
            if (obj == null) return type.IsValueType ? Activator.CreateInstance(type) : null;

            Type underlyingType = Nullable.GetUnderlyingType(type);
            // 如果待转换对象的类型与目标类型兼容，则无需转换
            if (type.IsInstanceOfType(obj)) 
            {
                return obj;
            }
            // 如果待转换的对象的基类型为枚举
            else if ((underlyingType ?? type).IsEnum) 
            {
                // 如果目标类型为可空枚举，并且待转换对象为null 则直接返回null值
                if (underlyingType != null && string.IsNullOrEmpty(obj.ToString())) 
                {
                    return null;
                }
                else
                {
                    return Enum.Parse(underlyingType ?? type, obj.ToString());
                }
            }
            // 如果目标类型的基类型实现了IConvertible，则直接转换
            else if (typeof(IConvertible).IsAssignableFrom(underlyingType ?? type)) 
            {
                try
                {
                    return Convert.ChangeType(obj, underlyingType ?? type, null);
                }
                catch
                {
                    return underlyingType == null ? Activator.CreateInstance(type) : null;
                }
            }
            else
            {
                TypeConverter converter = TypeDescriptor.GetConverter(type);
                if (converter.CanConvertFrom(obj.GetType()))
                {
                    return converter.ConvertFrom(obj);
                }
                ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    object o = constructor.Invoke(null);
                    PropertyInfo[] propertys = type.GetProperties();
                    Type oldType = obj.GetType();
                    foreach (PropertyInfo property in propertys)
                    {
                        PropertyInfo p = oldType.GetProperty(property.Name);
                        if (property.CanWrite && p != null && p.CanRead)
                        {
                            property.SetValue(o, ConvertToObject(p.GetValue(obj, null), property.PropertyType), null);
                        }
                    }
                    return o;
                }
            }
            return obj;
        }

    }
}
