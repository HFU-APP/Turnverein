using System;
using Turnverein.Services;
using Turnverein.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Turnverein
{
    public partial class App : Application
    {
        private static TokenDataBaseController tokenDataBase;
        private static AccountDataBaseController accountDataBase;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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

        public static AccountDataBaseController AccountDataBase
        {
            get
            {
                if (accountDataBase == null)
                {
                    accountDataBase = new AccountDataBaseController();
                }

                return accountDataBase;
            }
        }

        public static TokenDataBaseController TokenDataBase
        {
            get
            {
                if (tokenDataBase == null)
                {
                    tokenDataBase = new TokenDataBaseController();
                }

                return tokenDataBase;
            }
        }
    }
}
