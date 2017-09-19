using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer
{
    class Utilities
    {

        public string convertToEastern(string originalTime)
        {
            DateTime dt = DateTime.ParseExact(originalTime, "yy-MM-dd'T'HH:mm:ssK",
                                  CultureInfo.InvariantCulture,
                                  DateTimeStyles.AdjustToUniversal);

            TimeZoneInfo easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById(
                                 "Eastern Standard Time");

            DateTime easternDateTime = TimeZoneInfo.ConvertTimeFromUtc(dt,
                                                                       easternTimeZone);

            return easternDateTime.ToString();
        }

        string dateUrl(DateTime day)
        {

            string datePage = "";



            datePage = String.Format("{0:yyyyMMdd}", day);

            return datePage;

            //http://www.espn.com/mlb/probables/_/date/20170824
        }

    }
}
