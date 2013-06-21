using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class SystemExtensions
    {
        public static TReturn IfNotNull<TReturn, T>(this T item, Func<T, TReturn> getter) where T : class
        {
            if (item == null)
            {
                return default(TReturn);
            }
            return getter(item);
        }

        public static bool IsNotNull<TReturn, T>(this T item, Func<T, TReturn> getter) where T : class
        {
            return (item.IfNotNull(getter) != null);
        }

        public static bool NotNullAny<TReturn, T>(this T item, Func<T, IEnumerable<TReturn>> getter) where T : class
        {
            return item.IfNotNull(getter).IsAny();
        }

        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }

        public static string TodayDtTmStr(this DateTime dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }

            string t = dateTime.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);

            if (dateTime.Date != DateTime.Today.Date)
            {
                return dateTime.ToString(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern) + " " + t;
            }
            else
            {
                return t;
            }
        }

        public static string Sentence(params string[] words)
        {
            return JoinOnly(" ", words) + ".";
        }

        public static string JoinOnly(string separator, params string[] value)
        {
            return String.Join(separator, value.Where(s => !string.IsNullOrEmpty(s)));
        }

        public static string SafeSub(this string text, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(text) || startIndex >= text.Length)
            {
                return string.Empty;
            }

            if ((startIndex + length) > text.Length)
            {
                length = text.Length - startIndex;
            }

            return text.Substring(startIndex, length);
        }

        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;         // the actual index could have shifted due to the removal
            list.Insert(newIndex, item);
        }

        public static String ConvertToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        public static EnumType ConverToEnum<EnumType>(this string enumStr)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), enumStr.Trim(), true);
        }

        public static int ConvertToInt(this Enum eff)
        {
            return Convert.ToInt32(eff);
        }

        public static EnumType ConverToEnum<EnumType>(this Int32 enumInt)
        {
            return (EnumType)Enum.ToObject(typeof(EnumType), enumInt);
        }

        public static int ToInt(this decimal deci)
        {
            return Decimal.ToInt32(deci);
        }

        public static int? ToInt(this decimal? deci)
        {
            return Convert.ToInt32(deci);
        }

        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

    }
}