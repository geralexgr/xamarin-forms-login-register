using System;
using System.ComponentModel;
using System.Windows.Input;
using sample.Views;
using Xamarin.Forms;

namespace sample.ViewModels
{
    public class RegisterViewModel: INotifyPropertyChanged
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (message == value)
                    return;

                message = value;
                OnPropertyChanged("Message");
            }
        }




        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }



        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {

                    if (String.IsNullOrEmpty(this.Email) || String.IsNullOrEmpty(this.ConfirmPassword)
                         || String.IsNullOrEmpty(this.Password) || String.IsNullOrEmpty(this.UserName))
                        Message = "All fields are required.";


                    else
                    {
                        Message = "Register successful!";
                        await App.Current.MainPage.DisplayAlert("Success", "Email=" + this.Email + " Password=" + this.Password + " Username="+this.UserName, "OK");
                    }
                });
            }
        }


        public ICommand NavigateToLoginPage
        {
            get
            {
                return new Command(async () => {
                    await App.Current.MainPage.Navigation.PushModalAsync(new LoginView(), true);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
