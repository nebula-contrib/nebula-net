using Nebula.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NebulaNet
{
    internal static class ValueMappingExtensions
    {
        internal static object Mapping(this @Value value, Type targetType)
        {
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
                case "Date":
                    return value.DVal;
                case "Time":
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
                case "String[]":
                    return value.LVal.Values.Select(x => x.Mapping(typeof(string))).Cast<string>().ToArray();
                case "Int32[]":
                    return value.LVal.Values.Select(x => x.Mapping(typeof(int))).Cast<int>().ToArray();
                case "List`1"://List<T>
                    var type = targetType.GetGenericArguments()[0];
                    return value.LVal.Values.Select(x => x.Mapping(type)).Cast<string>().ToList();
                default:
                    return new TypeLoadException();
            }
        }
    }
}
