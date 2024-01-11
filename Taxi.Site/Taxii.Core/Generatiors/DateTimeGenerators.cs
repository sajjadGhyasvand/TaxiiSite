﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxii.Core.Generatiors
{
    public static class DateTimeGenerators
    {
        public static string GetShamsiDate()
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
        }

        public static string GetShamsiTime()
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetHour(DateTime.Now).ToString("00") + "/" + pc.GetMinute(DateTime.Now).ToString("00") + "/" + pc.GetSecond(DateTime.Now).ToString("00");

        }
    }
}
