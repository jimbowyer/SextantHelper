using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using SextantHelper.iOS;

[assembly: ResolutionGroupName("RedlidConsulting")]
[assembly: ExportRenderer(typeof(Entry), typeof(NumericKeyboardEntryRenderer))]
namespace SextantHelper.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    } //class app

    public class NumericKeyboardEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
            base.OnElementChanged(e);

            if (Control == null) return;

            if (e.NewElement.Keyboard == Keyboard.Numeric)
            {
                Control.KeyboardType = UIKeyboardType.NumbersAndPunctuation;
            }
        }
    }


} //ns
