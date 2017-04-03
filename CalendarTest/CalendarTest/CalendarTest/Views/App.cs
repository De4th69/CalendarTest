using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarTest.Views
{
    public class App : Application
    {
        public App()
        {
            MainPage = new CalendarTestPage();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
