using System;
using System.Collections.Generic;
using System.Text;

namespace Nebula.Common
{
    internal static class NebulaNetExtensions
    {
        internal static object GetValue(this @Value value, Type targetType)
        {
            switch (Type.GetTypeCode(targetType))
            {
                case TypeCode.Boolean:
                    return value.BVal;
                case TypeCode.Int32:
                    return (int)value.IVal;
                case TypeCode.Int64:
                    return value.IVal;
                case TypeCode.Double:
                    return value.FVal;
                case TypeCode.String:
                    return System.Text.Encoding.UTF8.GetString(value.SVal);
                case TypeCode.DateTime:
                    return value.DtVal;
                default:
                    return default;
            }
        }
    }
}
