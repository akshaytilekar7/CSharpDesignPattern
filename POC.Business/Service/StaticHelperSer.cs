using System;

namespace POC.Business.Service
{
    public static class StaticHelperSer
    {
        public static DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public static bool SomeStaticMethod(string input)
        {
            // Let's pretend this method hits a database or service.
            return !string.IsNullOrEmpty(input);
        }
    }
}
