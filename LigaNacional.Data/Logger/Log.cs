using System;

namespace LigaNacional.Data.Logger
{
    public class Log
    {
        public static void WriteError(Exception ex)
        {
            WriteError("", ex);
        }

        public static void WriteError(string message ,Exception ex)
        {

        }
    }
}
