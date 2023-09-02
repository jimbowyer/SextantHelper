using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SextantHelper.Models
{ 
    public class PageSightModel : BindableObject
    {
        private ObservableCollection<Sight> mSights;
        public ObservableCollection<Sight> MySights
        {
            get
            {
                return mSights;
            }
            set
            {
                mSights = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcNoonCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        

        public PageSightModel()
        {
            CalcNoonCommand = new Command<Sight>(async model =>
            {
                int iSightDegrees =model.Degrees;
                decimal dSightMinutes = model.Minutes;
                int iDecDegrees;
                decimal dDecMinutes;
                string sDecDegrees;
                string sDecMinutes;
                bool bValidDeclination;
                string sLongDegrees;
                string sLongMinutes;
                string sLatDegrees;
                string sLatMinutes;
                bool bConfirmed;
                StringBuilder sbResult =  new StringBuilder();

                bConfirmed = await DisplayConfirmation("Calculate noon position for selected sight?");
                if (!bConfirmed) { return; }

                sDecDegrees = await DisplayPromptAsync("Declination Degrees", "Enter Degree part for current declination ", "OK", "Cancel", null, 8,
                                        kb: Keyboard.Numeric, "");
                sDecMinutes = await DisplayPromptAsync("Declination Minutes", "Enter Minute part for current declination inc decimal ", "OK", "Cancel", null, 8,
                                        kb: Keyboard.Numeric, "");

                bValidDeclination = int.TryParse(sDecDegrees, out iDecDegrees);
                bValidDeclination = decimal.TryParse(sDecMinutes, out dDecMinutes);

                if (!bValidDeclination)
                {
                    DisplayAlert("Invalid Declination entered", "Please try again. Degrees must integer, minutes can be decimal.", "OK");
                    return;
                }

                //Do Noon Position math:
                //#1 CALC LATITUDE (90° - sight + declination):
                sLatDegrees = (89 - iSightDegrees + iDecDegrees).ToString();
                sLatMinutes = (60 - dSightMinutes + dDecMinutes).ToString();
                //#2 CALC LONGITUDE( [utc - 12hr] x 15):
                DateTime dteTmp;
                dteTmp = model.TimeTaken.AddHours(-12);
                int iTmp = 15 * dteTmp.ToUniversalTime().Hour;
                double dLong = 0.25 * dteTmp.ToUniversalTime().Minute;
                dLong = iTmp + dLong; 
                //convert decimal part to minutes
                sLongDegrees = dLong.ToString();
                sLongDegrees = sLongDegrees.Substring(0, sLongDegrees.IndexOf("."));
                sLongMinutes = dLong.ToString();
                sLongMinutes = sLongMinutes.Substring(sLongMinutes.IndexOf("."), sLongMinutes.Length - sLongMinutes.IndexOf("."));
                sLongMinutes = "0" + sLongMinutes;
                sLongMinutes = (Convert.ToDouble(sLongMinutes) * 60).ToString();
                
                //#3 FORMAT & DISPLAY Result
                sbResult.Append ("Latitude: " + sLatDegrees + "° ");
                sbResult.Append(sLatMinutes + "'");
                if (Convert.ToInt32(sLatDegrees) >0)
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
                DisplayAlert("Calculated Noon Position", sbResult.ToString(), "OK");

            });

            DeleteCommand = new Command<Sight>(model =>
            {
                MySights.Remove(model);   
            });

            AddCommand = new Command<Sight>(async model =>
            {
                //Get sight reading from user:
                string sDegrees = "";
                string sMinutes = "";
                bool bValidDeg = false;
                bool bValidMin = false;
                Sight newSight = null;
                int iDegrees;
                decimal dMinutes;
                DateTime dteTime = DateTime.Now; // ToUniversalTime().ToString("HH:mm:ss");

                while (!bValidDeg)
                {
                    sDegrees = await DisplayPromptAsync("Degrees", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        kb: Keyboard.Numeric, "");
                    bValidDeg = int.TryParse(sDegrees, out iDegrees);
                    if (bValidDeg)
                    {
                        bValidDeg = (iDegrees < 360);
                        if (!bValidDeg)
                        {
                            DisplayAlert("Please re-enter", "Must be <360", "OK");
                            sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        kb: Keyboard.Numeric, "");
                        }
                    }
                    else
                    {
                        DisplayAlert("Please re-enter", "Must be int", "OK");
                        sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        kb: Keyboard.Numeric, "");
                    };
                    if (bValidDeg)
                    {
                        //valid degree reading so store and ask user for minutes
                        while (!bValidMin)
                        {
                            iDegrees = int.Parse(sDegrees);
                            sMinutes = await DisplayPromptAsync("Minutes", "Enter Minutes (inc decimal)", "OK", "Cancel", null, 8,
                                                kb: Keyboard.Numeric, "");
                            bValidMin = decimal.TryParse(sMinutes, out dMinutes);
                            if (bValidMin)
                            {
                                newSight = new Sight(dteTime, iDegrees, dMinutes);                               
                            }
                        } //while min
                    }
                } //while deg

                //add to collection view.
                // *TO DO*... persist state between app starts
                if (newSight != null)
                {
                    if (MySights == null)
                    {
                        MySights = new ObservableCollection<Sight>();
                    }
                    MySights.Add(newSight);
                }
             });
         } //ctor

        private async Task<string> DisplayPromptAsync(string s1, string s2, string s3, string s4, string s5, int i6, Keyboard kb, string s8)
        {
            string sResult = "";
            sResult = await Application.Current.MainPage.DisplayPromptAsync(s1, s2, s3, s4, s5, i6, kb, s8);
            return sResult;
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
             Application.Current.MainPage.DisplayAlert(v1, v2, v3);
        }

        private async Task<bool> DisplayConfirmation(string sQuestion)
        {
            string sResult;
            sResult = await Application.Current.MainPage.DisplayActionSheet(sQuestion, "Cancel", "Yes");
            if (sResult != "Yes") return false; else return true;       
        }

        private async Task<bool> CancelAlert(string v1, string v2, string v3, string v4)
        {
             return await Application.Current.MainPage.DisplayAlert(v1, v2, v3, v4);
        }



    } //class PageReproModel
}//ns
