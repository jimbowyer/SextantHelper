using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SextantHelper
{
    public partial class PageSights : ContentPage
    {
        private DateTime mUtcTime = DateTime.Now;
        private bool mbSnapping = false;
        private List<Sight> mSightList = new List<Sight>(); //sight list

        public PageSights()
        {
            InitializeComponent();
            lvSights.ItemsSource = new List<Sight>();
            lvSights.ItemsSource = mSightList;

            Device.StartTimer(TimeSpan.FromSeconds(1 / 60f), () =>
            {
                //Force repaint and update of clock text
                canvasView.InvalidateSurface();
                return true;
            });

            btnSnap.Clicked += async (sender, args) =>
            {
                //open readings pop up:
                string sDegrees = "";
                string sMinutes = "";
                bool bValidDeg = false;
                bool bValidMin = false;
                Sight newSight = null;
                int iDegrees;
                decimal dMinutes;
                mbSnapping = true;
                string sTime = mUtcTime.ToUniversalTime().ToString("HH:mm:ss");

                while (!bValidDeg)
                {
                    sDegrees = await DisplayPromptAsync("Degrees", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        keyboard: Keyboard.Numeric, "");
                    bValidDeg = int.TryParse(sDegrees, out iDegrees);
                    if (bValidDeg)
                    {
                        bValidDeg = (iDegrees < 360);
                        if (!bValidDeg)
                        {
                            await DisplayAlert("Please re-enter", "Must be <360", "OK");
                            sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        keyboard: Keyboard.Numeric, "");
                        }
                    }

                    else
                    {
                        await DisplayAlert("Please re-enter", "Must be int", "OK");
                        sDegrees = await DisplayPromptAsync("Must be int & <360...", "Enter Degrees ", "OK", "Cancel", null, 8,
                                        keyboard: Keyboard.Numeric, "");
                    };
                    if (bValidDeg)
                    {
                        //valid degree reading so store and ask user for minutes
                        while (!bValidMin)
                        {
                            iDegrees = int.Parse(sDegrees);
                            sMinutes = await DisplayPromptAsync("Minutes", "Enter Minutes (inc decimal)", "OK", "Cancel", null, 8,
                                                keyboard: Keyboard.Numeric, "");
                            bValidMin = decimal.TryParse(sMinutes, out dMinutes);
                            if (bValidMin)
                            {
                                newSight = new Sight(mUtcTime, iDegrees, dMinutes);
                                mSightList.Add(newSight);
                                
                            }
                        } //while min
                    }
                } //while deg

                //Store result as new Sight obj, add to list *TO DO*... either List<t> or GUI List obj
                if (newSight != null)
                {
                    
                    lvSights.ItemsSource = null;
                    lvSights.ItemsSource = mSightList;
                    
                }

                mbSnapping = false; //allow clock refresh again

            }; //btnSnap
        } //ctor


        private SKPaint GetPaintColor(SKPaintStyle style, string hexColor, float strokeWidth = 0, SKStrokeCap cap = SKStrokeCap.Round, bool IsAntialias = true)
        {
            return new SKPaint
            {
                Style = style,
                StrokeWidth = strokeWidth,
                Color = string.IsNullOrWhiteSpace(hexColor) ? SKColors.White : SKColor.Parse(hexColor),
                StrokeCap = cap,
                IsAntialias = IsAntialias
            };
        }

        private void canvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            if (!mbSnapping) //skip if we are reading sight
            {
                //force repaint
                SKSurface surface = e.Surface;
                SKCanvas canvas = surface.Canvas;
                canvas.Clear();

                //Update UTC clock
                mUtcTime = DateTime.Now;
                timeTxt.Text = mUtcTime.ToUniversalTime().ToString("HH:mm:ss");
            }

        }
    }
}