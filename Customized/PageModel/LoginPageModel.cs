using System;
using System.ComponentModel;
using System.Windows.Input;
using Customized.Model;
using Customized.View;
using Xamarin.Forms;

namespace Customized.PageModel
{
    public class LoginPageModel : INotifyPropertyChanged
    {

        
        //IMPLEMENT INTERFACES BEGIN
        public event PropertyChangedEventHandler PropertyChanged;
        //IMPLEMENT INTERFACES END


        
        //COMMAND PROPERTIES BEGIN
        public ICommand LoginCommand { get; }

        //COMMAND PROPERTIES END





        //PROPERTIES BEGIN
        private string _userName;

        public string Username {
            get=>_userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _passWord;

        public string Password
        {
            get => _passWord;
            set
            {
                _passWord = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        //PROPERTIES END





        //METHODS BEGIN

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public async void LoginMethod()
        {
            if (_userName == "A" && _passWord == "1")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Tabbed());
            }
            if (_userName != "A" || _passWord != "1")
            {
                await Application.Current.MainPage.DisplayAlert("Wrong Username or Password", "Try Again", "Ok");
            }
        }
        //METHODS END



        //CONSTRUCTOR BEGIN
        public LoginPageModel()
        {
            LoginCommand = new Command(LoginMethod);
            
        }
        //CONSTRUCTOR END
    }
}
