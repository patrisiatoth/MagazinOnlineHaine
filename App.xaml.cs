using System;
using MagazinOnlineHaine.Data;
using System.IO;

namespace MagazinOnlineHaine
{
    public partial class App : Application
    {
        static MagazinOnlineDatabase database;

        public static MagazinOnlineDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MagazinOnlineDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MagazinOnline.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell());
        }
    }
}