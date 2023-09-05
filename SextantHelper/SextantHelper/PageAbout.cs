using System;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SextantHelper
{
    public class PageAbout : ContentPage
    {
        public PageAbout()
        {
            const string cSTR_TOP = "Sextant Helper";
            const string cSTR_ABOUT = "Sextant Helper aims to help you capture celestial observations from a Sextant. It does not replace the need for a sextant. No warranties expressed or implied. Logo courtesy flaticon.com & all content copyright of originators & shared with their consent.";
            const string cWEB = "github.com/jimbowyer/SextantHelper";

            var assembly = typeof(SextantHelper.App).GetTypeInfo().Assembly;
            var assemName = new AssemblyName(assembly.FullName);
            string sVersion = "Version: " + assemName.Version.ToString();

            BackgroundColor = Color.White;

            Button btnLink = new Button() { Text = cWEB, TextColor = Color.Blue };
            btnLink.Clicked += (sender, args) =>
            {
                Uri uri = new Uri("http://" + cWEB);
                Launcher.OpenAsync(uri);
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                Padding = new Thickness(5),
                Spacing = 30,
                Children = {
                    new Label { Text = cSTR_TOP, TextColor= Color.Navy, HorizontalTextAlignment= TextAlignment.Center},
                    new Image
                    {
                        Source = "sextant_about.png",
                        IsVisible = true,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Label { Text = sVersion, TextColor= Color.Black, HorizontalTextAlignment= TextAlignment.Center},
                    new Label { Text = cSTR_ABOUT, TextColor= Color.Black, HorizontalTextAlignment= TextAlignment.Center},
                }
            };
        } //ctor
    } //class
} //ns