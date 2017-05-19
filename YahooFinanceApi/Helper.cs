﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace YahooFinanceApi
{
    internal static class Helper
    {
        private readonly static DateTime DefaultUnixDateTime = new DateTime(1970, 1, 1);

        public static string Name<T>(this T @enum)
        {
            string name = @enum.ToString();
            if (typeof(T).GetMember(name).First().GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attr && attr.IsValueSetExplicitly)
                name = attr.Value;
            return name;
        }

        public static T GetValue<T>(this string str)
            => (T)Convert.ChangeType(str, typeof(T));

        public static string ToUnixTimestamp(this DateTime dateTime)
            => ((DateTimeOffset)dateTime).ToUnixTimeSeconds().ToString();
    }
}
