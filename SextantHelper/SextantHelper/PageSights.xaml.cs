using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SextantHelper.Models;

namespace SextantHelper
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSights : ContentPage
    {
        private DateTime mUtcTime = DateTime.Now;     
        private List<Sight> mSightList = new List<Sight>(); //sight list

        public PageSights()
        {
            InitializeComponent();
            BindingContext = new PageSightModel();

            Device.StartTimer(TimeSpan.FromSeconds(1 / 60f), () =>
            {
                //Force repaint and update of clock text
                canvasView.InvalidateSurface();
                return true;
            });

            btnSnap.Clicked += async (sender, args) =>
            {
                //implemented in PageSightModel and bound with ctrl at runtime
            }; 

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
        } //GetPaintColor

        private void canvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            //force repaint
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            //Update UTC clock
            mUtcTime = DateTime.Now;
            timeTxt.Text = mUtcTime.ToUniversalTime().ToString("HH:mm:ss");
            
        } //canvas_PaintSurface
    }
} //ns