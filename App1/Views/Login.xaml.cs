using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Windows.Security.Credentials;
using System.Threading.Tasks;


namespace App1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (await Helper.MicrosoftPassportAvailableCheckAsync())
            {
                TxtBoxResult.Text = "Passport is available!!";
            }
            else
            {
                TxtBoxResult.Text = "Passport is not available!!";
            }

            Helper.RemovePassportAccountAsync("gagaga");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }

    public static class Helper
    {
        public static async Task<bool> MicrosoftPassportAvailableCheckAsync()
        {
            bool keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
            if (keyCredentialAvailable == false)
            {
                // Key credential is not enabled yet as user 
                // needs to connect to a Microsoft Account and select a PIN in the connecting flow.                
                return false;
            }

            return true;
        }

        public static async void RemovePassportAccountAsync(String accountName)
        {
            // Open the account with Passport
            KeyCredentialRetrievalResult keyOpenResult = await KeyCredentialManager.OpenAsync(accountName);

            if (keyOpenResult.Status == KeyCredentialStatus.Success)
            {
                // In the real world you would send key information to server to unregister
                //e.g. RemovePassportAccountOnServer(account);
            }

            // Then delete the account from the machines list of Passport Accounts
            //await KeyCredentialManager.DeleteAsync(accountName);
        }
    }

}


