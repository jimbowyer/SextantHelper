﻿using System;
using System.Reflection;
using Xamarin.Forms;

namespace SextantHelper
{
    public class PageAbout : ContentPage
    {
        public PageAbout()
        {
            const string cSTR_TOP = "Sextant Helper - From Red Lid";
            const string cSTR_ABOUT = "Sextant Helper aims to help you capture celestial observations from a Sextant. It does not replace the need for a sextant. Content copyright of originators & shared with their consent.";
            
            var assembly = typeof(SextantHelper.App).GetTypeInfo().Assembly;
            var assemName = new AssemblyName(assembly.FullName);
            string sVersion = "Version: " + assemName.Version.ToString();

            BackgroundColor = Color.White;
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                Padding = new Thickness(5),
                Spacing = 30,
                Children = {
                    new Label { Text = cSTR_TOP, TextColor= Color.Black, HorizontalTextAlignment= TextAlignment.Center},
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