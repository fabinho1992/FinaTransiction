using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fina.Core.Commom
{
    public static class DateTimeExtension
    {
        public static DateTime GetFirstDay(this DateTime date, int? Year = null, int? Month = null)// Aqui pego o primeiro dia do mês ou o primeiro dia do mês passado
        {
            return new DateTime(Year ?? date.Year, Month ?? date.Month, day: 1);
        }
        public static DateTime GetLastDay(this DateTime date, int? Year = null, int? Month = null)// Aqui recupero o último dia do mês
        {
            return new DateTime(Year ?? date.Year, Month ?? date.Month, day: 1)
                .AddMonths(1)
                .AddDays(-1);

        }
    }
}
