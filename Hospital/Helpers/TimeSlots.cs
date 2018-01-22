using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Helpers
{
    public static class Timeslots
    {
        private static Dictionary<int, string> time;

        static Timeslots()
        {
            time = new Dictionary<int, string>();
            time.Add(1, "09:00");
            time.Add(2, "10:00");
            time.Add(3, "11:00");
            time.Add(4, "12:00");
            time.Add(5, "13:00");
            time.Add(6, "14:00");
            time.Add(7, "15:00");
            time.Add(8, "16:00");
        }

        public static Dictionary<int, string> GetALL()
        {
            return time;

        }

        public static string GetTime(int id)
        {
            if (time.ContainsKey(id))
            {
                return time[id];
            }
            else
            {
                return string.Empty;
            }
        }
        }
}