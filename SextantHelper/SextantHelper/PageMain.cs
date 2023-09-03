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
            this.Children.Add(new PageAide
            {
                Title = "Aide Memoir"
            }
            );

            this.Children.Add(new PageAbout
            {
                Title = "About"
            });


        } //ctor
    } //class PageMain 
}