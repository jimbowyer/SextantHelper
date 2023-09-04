using System;
using System.Collections.ObjectModel;
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
                bool bConfirmed;
                string sResult = string.Empty;

                bConfirmed = await DisplayConfirmation("Calculate noon position for selected sight?");
                if (!bConfirmed) { return; }

                //Get user input for declination values:
                sDecDegrees = await DisplayPromptAsync("Declination Degrees", "Enter Degree part for current declination value ", "OK", "Cancel", null, 8, kb: Keyboard.Numeric, "");
                sDecMinutes = await DisplayPromptAsync("Declination Minutes", "Enter Minute part for current declination inc decimal ", "OK", "Cancel", null, 8,kb: Keyboard.Numeric, "");

                bValidDeclination = int.TryParse(sDecDegrees, out iDecDegrees);
                bValidDeclination = decimal.TryParse(sDecMinutes, out dDecMinutes);
                
                if (iDecDegrees < -90 || iDecDegrees >90 ) { bValidDeclination = false; };
                if (dDecMinutes < 0) { bValidDeclination = false; };

                if (!bValidDeclination)
                {
                    DisplayAlert("Invalid Declination entered", "Please try again. Degrees must integer, minutes can be decimal.", "OK");
                    return;
                }

                //get formatted result for a calculated noon position using sight readings:
                SolarWorker objSun = new SolarWorker();
                sResult = objSun.GetNoonPosition(iSightDegrees, dSightMinutes, iDecDegrees, dDecMinutes, model.TimeTaken);
                DisplayAlert("Calculated Noon Position", sResult.ToString(), "OK");
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
                    sDegrees = await DisplayPromptAsync("Degrees", "Enter Degrees ", "OK", "Cancel", null, 8, kb: Keyboard.Numeric, "");
                    bValidDeg = int.TryParse(sDegrees, out iDegrees);
                    if (bValidDeg)
                    {
                        bValidDeg = (iDegrees < 360);
                        if (!bValidDeg)
                        {
                            DisplayAlert("Please re-enter", "Must be <360", "OK");
                            sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8, kb: Keyboard.Numeric, "");
                        }
                    }
                    else
                    {
                        DisplayAlert("Please re-enter", "Must be integer", "OK");
                        sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8, kb: Keyboard.Numeric, "");
                    };
                    if (bValidDeg)
                    {
                        //valid degree reading so store and ask user for minutes
                        while (!bValidMin)
                        {
                            iDegrees = int.Parse(sDegrees);
                            sMinutes = await DisplayPromptAsync("Minutes", "Enter Minutes (inc decimal)", "OK", "Cancel", null, 8, kb: Keyboard.Numeric, "");
                            bValidMin = decimal.TryParse(sMinutes, out dMinutes);
                            if (bValidMin)
                            {
                                newSight = new Sight(dteTime, iDegrees, dMinutes);                               
                            }
                        } //while min
                    }
                } //while deg

                //add to collection view.
                // *NICE DO*... add persist state between app starts
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
