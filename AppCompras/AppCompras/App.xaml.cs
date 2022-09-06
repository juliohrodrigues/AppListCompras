using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCompras.Helper;

using System.IO;

namespace AppCompras
{
    public partial class App : Application
    {
        static SQLiteDatabase database;
        public static SQLiteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDatabase(Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), "AppCompras.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Cadastrar());
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
