using Xamarin.Forms;
using System.Reflection;
using System;
using Xamarin.Essentials;

namespace SextantHelper
{
    public class PageAbout : ContentPage
    {
        public PageAbout()
        {
            const string cSTR_ABOUT = "Shared for educational purposes. No warranties expressed or implied. Content copyright of originators & shared with their consent. Logo courtesy flaticon.com";
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
                    new Image
                    {
                        Source = "about.jpg",
                        IsVisible = true,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Label { Text = sVersion, TextColor= Color.Black, HorizontalTextAlignment= TextAlignment.Center},
                    new Label { Text = cSTR_ABOUT, TextColor= Color.Black, HorizontalTextAlignment= TextAlignment.Center},
                    btnLink
                }
            };

        } //PageAbout
    }
}

