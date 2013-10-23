using System;
using System.Text.RegularExpressions;
using LigaNacional.Data.Logger;

namespace LigaNacional.Data.Helper
{
    public static class Extension
    {
        public static long ToLong(this object value)
        {
            return Convert.ToInt64(value.NullValue(0));
        }

        public static int ToInt(this object value)
        {
            return Convert.ToInt32(value.NullValue(0));
        }

        public static bool ToBoolean(this object value)
        {
            return Convert.ToBoolean(value.NullValue(false));
        }

        public static string ToString(this object value)
        {
            return Convert.ToString(value.NullValue(""));
        }

        public static string ToSafeString(this object value)
        {
            return Convert.ToString(value.NullValue(""));
        }

        public static double ToDouble(this object value)
        {
            return Convert.ToDouble(value.NullValue(0));
        }

        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }

        public static decimal ToDecimal(this object value)
        {
            return Convert.ToDecimal(value.NullValue(0));
        }

        public static string DefaultStringValue(this object value)
        {
            return IsNullOrEmpty(value) ? "" : value.ToString();
        }

        public static object NullValue(this object value, object replaceValue)
        {
            return IsNullOrEmpty(value) ? replaceValue : value;
        }


        public static bool IsValid(this object value)
        {
            if (IsNullOrEmpty(value))
                return false;

            return true;
        }

        public static bool IsNullOrEmpty(this object value)
        {
            if (value == null)
                return true;

            if (value == DBNull.Value)
                return true;

            if (Convert.IsDBNull(value))
                return true;


            if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()))
            {
                var st = typeof(string);
                if (value.GetType() == st)
                    return true;

            }

            return false;
        }

        public static bool IsNumber(this object value)
        {
            try
            {
                var strvalue = value.ToSafeString();
                var regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(strvalue);
            }
            catch (Exception ex)
            {
                Log.WriteError(ex);
                return false;
            }
        }



    }
}
