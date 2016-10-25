using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace AppSQL
{
    public class App : Application
    {
        public App()
        {


            Page2 pag2 = new Page2();
            pag2.Title = "Agenda";
            pag2.BackgroundColor = Color.Gray;

            Page1 Pag1 = new Page1();
            Pag1.Title = "Agenda";
            Pag1.BackgroundColor = Color.Gray;



            // The root page of your application
            MainPage = new TabbedPage
            {


                Children = {

                    pag2,
                    Pag1

                    }

            };
        }


        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
