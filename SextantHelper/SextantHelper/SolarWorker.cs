using System;
using System.Text;


namespace SextantHelper
{
    public class SolarWorker
    {
        public SolarWorker()
        {
        }

        private string minutesToClock(double time)
        {
            // Format decimal minutes to hours, minutes, and seconds text.
            double hours = Math.Truncate(time / 60);
            double minutes = Math.Truncate(time - (hours * 60));
            double seconds = Math.Round(Math.Abs(time - (hours * 60) - minutes) * 60);
            return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        public string solarNoon(double longitudeOffset)
        {
            const int noonMinutes = 12 * 60;
            return minutesToClock(noonMinutes + longitudeOffset);
        }

        private double getOffsetMinutes()
        {
            // Get the local offset from UTC in minutes:
            DateTime dLocal = DateTime.Now; //uses compute clock, need to adjust if offline?
            DateTime dUTC = DateTime.UtcNow;
            TimeSpan tsDiff = dLocal.Subtract(dUTC);
            return tsDiff.TotalMinutes;
        }

        public double longitudeOffset(double eot, double longitude)
        {
            // Adjust EOT for longitude and timezone.
            return -1 * (eot + (4 * longitude) - getOffsetMinutes());
        }

        public double EquationOfTime(double days)
        {
            // System of equations based upon Fourier analysis of a large MICA data set.
            // Only valid from 2000 to 2050
            double cycle = Math.Round(days / 365.25);  //cast to round result
            double theta = 0.0172024 * (days - 365.25 * cycle);
            double amp1 = 7.36303 - cycle * 0.00009;
            double amp2 = 9.92465 - cycle * 0.00014;
            double rho1 = 3.07892 - cycle * 0.00019;
            double rho2 = -1.38995 + cycle * 0.00013;
            // Equation Of Time (EOT)
            double eot1 = amp1 * Math.Sin(1 * (theta + rho1));
            double eot2 = amp2 * Math.Sin(2 * (theta + rho2));
            double eot3 = 0.31730 * Math.Sin(3 * (theta - 0.94686));
            double eot4 = 0.21922 * Math.Sin(4 * (theta - 0.60716));
            double eot = 0.00526 + eot1 + eot2 + eot3 + eot4; // minutes
            return eot;
        }

        public double epoch2kDay(Query q)
        {
            // Days since Jan 1, 2000 12:00 UT
            var oneDay = 1000 * 60 * 60 * 24; // in milliseconds
            DateTime queryDate = new DateTime(q.Year, q.Month, q.Day, 12, 0, 0); //.getTime();
            DateTime epochYear = new DateTime(2000, 1, 1, 12, 0, 0);  //.getTime()

            return queryDate.Subtract(epochYear).TotalMilliseconds / oneDay; //simplify if always noon?           
        }

        public string GetNoonPosition(int iSightDegrees,decimal dSightMinutes, int iDecDegrees, decimal dDecMinutes, DateTime TimeTaken)
        {
            StringBuilder sbResult = new StringBuilder();
            string sLatDegrees;
            string sLatMinutes;
            string sLongDegrees;
            string sLongMinutes;

            try
            {
                //Do Noon Position math:
                //#1 CALC LATITUDE (90° - sight + declination):
                sLatDegrees = (89 - iSightDegrees + iDecDegrees).ToString();
                sLatMinutes = (60 - dSightMinutes + dDecMinutes).ToString();

                //#2 CALC LONGITUDE( [utc - 12hr] x 15):
                DateTime dteTmp;
                //dteTmp = model.TimeTaken.AddHours(-12);
                dteTmp = TimeTaken.AddHours(-12);
                int iTmp = 15 * dteTmp.ToUniversalTime().Hour;
                double dLong = 0.25 * dteTmp.ToUniversalTime().Minute;
                dLong = iTmp + dLong;
                //convert decimal part to minutes
                sLongDegrees = dLong.ToString("0.00");
                sLongDegrees = sLongDegrees.Substring(0, sLongDegrees.IndexOf("."));
                sLongMinutes = dLong.ToString("0.00");
                sLongMinutes = sLongMinutes.Substring(sLongMinutes.IndexOf("."), sLongMinutes.Length - sLongMinutes.IndexOf("."));
                sLongMinutes = "0" + sLongMinutes;
                sLongMinutes = (Convert.ToDouble(sLongMinutes) * 60).ToString();

                //#3 FORMAT RESULT STRING:
                sbResult.Append("Latitude: " + sLatDegrees + "° ");
                sbResult.Append(sLatMinutes + "'");
                if (Convert.ToInt32(sLatDegrees) > 0)
                {
                    sbResult.AppendLine("N");
                }
                else sbResult.AppendLine("S");
                sbResult.Append("Longitude: " + sLongDegrees + "° ");
                sbResult.Append(sLongMinutes + "'");
                if (dLong > 0)
                {
                    sbResult.AppendLine("W");
                }
                else sbResult.AppendLine("E");

                return sbResult.ToString();

            }
            catch (Exception ex)
            {
                return ("Unexpected error calculating noon position: " + ex.ToString());
            }

        } // GetNoonPosition

    } // class solarnoon

    public class Query
    {
        private int iYear;
        private int iMonth;
        private int iDay;
        private int iHour;
        private float fLongitude;

        public Query()
        { }

        public Query(DateTime dte2Use, float Longitude)
        {
            iYear = dte2Use.Year;
            iMonth = dte2Use.Month;
            iDay = dte2Use.Day;
            fLongitude = Longitude;
        }
        public int Year
        {
            get { return iYear; }
            set { iYear = value; }
        }

        public int Month
        {
            get { return iMonth; }
            set { iMonth = value; }
        }

        public int Day
        {
            get { return iDay; }
            set { iDay = value; }
        }

        public int Hour
        {
            //not used
            get { return iHour; }
            set { iHour = value; }
        }

        public float Longitude
        {
            get { return fLongitude; }
            set { fLongitude = value; }
        }

    } //class Query

} //ns
