
using Xamarin.Forms;

namespace SextantHelper
{
    public class PageMain : TabbedPage
    {
        public PageMain()
        {
            this.Children.Add(new PageSky
            {
                Title = "Sky Info",
                
            }
            );
            this.Children.Add(new PageSights
            {
                Title = "Sight Records",

            }
            );
           
        } //ctor
    } //class PageMain 
}