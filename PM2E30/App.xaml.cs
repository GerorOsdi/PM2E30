using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PM2E30.Control;

namespace PM2E30
{
    public partial class App : Application
    {

        static  DataBase db;

        public static DataBase dbPlace
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbPlaces.db3");
                    db = new DataBase(FolderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
