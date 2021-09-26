using System;

namespace EAT.Infrastruture.WPF.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool CompararDatas(DateTime data, DateTime dataASerComparada)
        {
            return data.Day == dataASerComparada.Day && data.Month == dataASerComparada.Month &&
                   data.Year == dataASerComparada.Year && data.Hour == dataASerComparada.Hour &&
                   data.Minute == dataASerComparada.Minute && data.Second == dataASerComparada.Second;
        }
    }
}
