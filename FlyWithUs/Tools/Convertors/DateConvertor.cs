using System;
using System.Globalization;

namespace FlyWithUs.Hosted.Service.Tools.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            string date = pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
            return date;
        }
    }
}
