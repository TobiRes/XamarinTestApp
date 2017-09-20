using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneworld
{
    public partial class App : Application
    {
        public static IList<string> PhoneNumbers { get; set; }

        public App()
        {
            InitializeComponent();
            PhoneNumbers = new List<string>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Application.Current.Properties["numbers"] = PhoneNumbers;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            if (Application.Current.Properties.ContainsKey("id"))
            {
                PhoneNumbers = Application.Current.Properties["id"] as IList<string>;
                // do something with id
            }
            // Handle when your app resumes
        }
    }
}