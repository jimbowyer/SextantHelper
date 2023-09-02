using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SextantHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAide : ContentPage
    {
        public PageAide()
        {
            InitializeComponent();

            string sUrl = "AideMemoir.htm";
            HtmlWebViewSource hSource = new HtmlWebViewSource();
            hSource.Html = LoadAMText(sUrl);

            wvAM.Source = hSource;
        } //ctor

        private string LoadAMText(string sURL)
        {
            string sRtn = "";
            Assembly assem = typeof(PageAide).GetTypeInfo().Assembly;
            Stream streamText = assem.GetManifestResourceStream("SextantHelper.Resources." + sURL);
            if (streamText != null)
            {
                using (StreamReader reader = new StreamReader(streamText))
                {
                    sRtn = reader.ReadToEnd();
                }
            }
            return sRtn;
        }
    }
}