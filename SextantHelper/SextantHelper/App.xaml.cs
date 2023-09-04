using Xamarin.Forms;

namespace SextantHelper
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageMain();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
