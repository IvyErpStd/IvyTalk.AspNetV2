using System;
using System.ComponentModel;

namespace IvyTalk.AspNet.Utilities
{
    internal static class TypeHelper
    {
        /// <summary>
        /// 可直接通过 <see cref="string"/> 进行转换
        /// </summary>
        public static bool CanConvertFromString(Type type)
        {
            return IsSimpleUnderlyingType(type) || HasStringConverter(type);
        }

        /// <summary>
        /// 潜在类型
        /// </summary>
        public static bool IsSimpleUnderlyingType(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                type = underlyingType;
            }

            return IsSimpleType(type);
        }

        /// <summary>
        /// 常见类型
        /// </summary>
        public static bool IsSimpleType(Type type)
        {
            return type.IsPrimitive ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(decimal) ||
                   type == typeof(Guid) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan);
        }

        public static bool HasStringConverter(Type type)
        {
            return TypeDescriptor.GetConverter(type).CanConvertFrom(typeof(string));
        }

        public static object GetDefaultValueForType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}