using System;
using Xamarin.Forms;

namespace Phoneworld
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber;
        int ursprungsnummer;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhoneworldTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                Int32.TryParse(phoneNumberText.Text, out ursprungsnummer);
                callButton.Text = "Rufe Binärzahl an: " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Anrufen";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            callHistoryButton.IsEnabled = true;
            App.PhoneNumbers.Add(translatedNumber + " - " + ursprungsnummer.ToString());

            if (await this.DisplayAlert(
                    "Binärzahl anrufen",
                    "Würden Sie gerne " + translatedNumber + " (" + ursprungsnummer + ") anrufen?",
                    "Ja",
                    "Nein"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(translatedNumber);
                }
            }
        }

        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}