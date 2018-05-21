using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Akavache;
using Xamarin.Forms;

using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APP_Adinco
{
    public partial class App : Application
    {
       
        public App()
        {
         InitializeComponent();
         MainPage = new MainView();
        }

      
      


      
        protected override void OnStart()
        {
           
           
        }

        protected override void OnSleep()
        {


           
          
        }

        protected override void OnResume()
        {
           
            // Handle when your app resumes
        }
    }
}
