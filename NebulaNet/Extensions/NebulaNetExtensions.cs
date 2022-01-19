using Nebula.Common;
using Nebula.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNet
{
    public static class NebulaNetExtensions
    {
        internal static object GetValue(this @Value value, Type targetType)
        {
            switch (targetType.Name)
            {
                case "Bool":
                    return value.BVal;
                case "Int32":
                    return (int)value.IVal;
                case "Int64":
                    return value.IVal;
                case "Double":
                    return value.FVal;
                case "String":
                    return Encoding.UTF8.GetString(value.SVal);
                case "DateTime":
                    return value.DtVal;
                case "String[]":
                    return value.LVal.Values.Select(x => x.GetValue(typeof(string))).Cast<string>().ToArray();
                case "Int32[]":
                    return value.LVal.Values.Select(x => x.GetValue(typeof(int))).Cast<int>().ToArray();
                case "List`1":
                    return value.LVal.Values.Select(x => x.GetValue(typeof(string))).Cast<string>().ToList();
                default:
                    return default;
            }
        }

        public static async Task<T[]> ToArrayAsync<T>(this Task<ExecutionResponse> executionTask)
        {
            var executionResponse = await executionTask;
            if (executionResponse.Data == null)
                return default;
            if (executionResponse.Data.Rows.Count != 1)
                return default;//不能解析多行

            return (T[])executionResponse.Data.Rows[0].Values[0].GetValue(typeof(T[]));
        }
        public static async Task<IList<T>> ToListAsync<T>(this Task<ExecutionResponse> executionTask)
        {
            var executionResponse = await executionTask;
            if (executionResponse.Data == null)
                return default;

            //获取列名
            var columnNames = executionResponse.Data.Column_names
                .Select(x => Encoding.UTF8.GetString(x).ToLower()).ToArray();

            //查找可用属性和数据索引
            var indexAndProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)//BindingFlags.IgnoreCase
                .Select(x => new { Index = Array.IndexOf(columnNames, x.Name.ToLower()), Prop = x })
                .Where(x => x.Index >= 0);

            //映射对象
            var result = new List<T>();
            foreach (var row in executionResponse.Data.Rows)
            {
                var o = Activator.CreateInstance<T>();
                foreach (var item in indexAndProps)
                {
                    item.Prop.SetValue(o, row.Values[item.Index].GetValue(item.Prop.PropertyType));
                }
                result.Add(o);
            }

            return result;
        }
    }
}
