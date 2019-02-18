using System;
using System.ComponentModel;
using System.Windows.Input;
using sample.Views;
using Xamarin.Forms;

namespace sample.ViewModels
{
    public class LoginViewModel: INotifyPropertyChanged
    {


        public string Email { get; set; }
        public string Password { get; set; }

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


        public ICommand LoginCommand
        {
            get
            {

                return new Command(
                    async () =>
                    {
                        IsBusy = false;
                        Message = "Login successful!";
                        await App.Current.MainPage.DisplayAlert("Success", "Email="+this.Email+" "+"Password="+this.Password, "OK");
                    });
            }
        }

        public ICommand NavigateToRegisterPage
        {
            get
            {
                return new Command(async () => {
                    await App.Current.MainPage.Navigation.PushModalAsync(new RegisterView(), true);
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
