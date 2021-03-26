using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealmApp3.Views;
namespace RealmApp3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new DeletePage();
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
