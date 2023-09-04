using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SextantHelper.Earth;


namespace SextantHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSky : ContentPage
    {
        public PageSky()
        {
            InitializeComponent();
            lblTimeZone.Text = ("Clock TZ : " + TimeZoneInfo.Local.DisplayName);
            txtSolar.Text = "Today is: " + DateTime.Now.ToString("m") + ". Set approx Longitude value above to enable calc. ";

            txtLong.Completed += async (sender, args) =>
            {
                int iGood;
                if (Int32.TryParse(txtLong.Text, out iGood) && (iGood > -181) && (iGood < 181))
                {
                    txtLong.Text = iGood.ToString() + "°";
                }
                else
                {
                    await DisplayAlert("Please re-enter Longitude", "Must be number from -180 to +180", "OK");
                    txtLong.Text = "";
                }
            };

            btnCalcSky.Clicked += async (sender, args) =>
            {
                Hemispheres hRequested;
                string sHemiAsk = await Application.Current.MainPage.DisplayActionSheet("Which hemisphere? N/S?", "Northern", "Southern");
                if (sHemiAsk == "Southern") hRequested = Hemispheres.Southern; else hRequested = Hemispheres.Northern;
                txtSolar.Text = DateTime.Now.ToString();

                StringBuilder sbSolar = new StringBuilder();
                SolarWorker solar = new SolarWorker();
                Query myQ = new Query();
                string sHold;
                long lLong;

                if (txtLong.Text == null)
                {
                    await DisplayAlert("Please re-enter", "Must be valid long", "OK");
                    return;
                }

                sHold = txtLong.Text;
                if (sHold.Length >= 1 && sHold.Substring(sHold.Length - 1) == "°")
                {
                    sHold = txtLong.Text.Remove(txtLong.Text.Length - 1, 1);
                }
                if (!long.TryParse(sHold, out lLong))
                {
                    await DisplayAlert("Please re-enter", "Must be valid long", "OK");
                    return;
                }
                //= Convert.ToInt64(txtLong.Text.Remove(txtLong.Text.Length -1, 1)); //remove °
                myQ = new Query(DateTime.Now, lLong); //value from entry

                //#1 get epoch days
                double days = solar.epoch2kDay(myQ);
                //sbSolar.AppendLine("Epoch (days) = " + days.ToString());

                //2 get Equation of Time
                double eot = solar.EquationOfTime(days);
                //sbSolar.AppendLine("Eq of Time = " + eot.ToString());

                //3 get offset
                double offset = solar.longitudeOffset(eot, myQ.Longitude);
                sbSolar.AppendLine("UTC offset (mins) = " + offset.ToString());

                //4 get solar noon
                string solarNoon = solar.solarNoon(offset);
                sbSolar.AppendLine("Solar noon for " + DateTime.Now.ToString("D"));

                string sLong = ("   @ longitude " + (myQ.Longitude.ToString()) + "°");
                if (myQ.Longitude > 0)
                { sLong = sLong + "E"; }
                else { sLong = sLong + "W"; }
                sbSolar.AppendLine(sLong);

                TimeSpan clockoffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
                sbSolar.AppendLine("   is : " + solarNoon + "hrs, (UTC " + clockoffset.ToString() + ")");
                sbSolar.AppendLine("~~~~~~~~~~~~");

                //now get moon phase details
                sbSolar.AppendLine(LunarWorker.CalculateMoonPhase(DateTime.Now.ToUniversalTime(), hRequested));
                txtSolar.Text = sbSolar.ToString();

            }; //btnCalcSky

        } //ctor
    } //class PageSky
}