using MyOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MyOrder.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private LoginModel _selectedUser = new LoginModel();
        private bool _isBusy = false;
        //private string _statusMessage = null;
        //bool IsSuccess;
        //int addSuccess;
        //public string UserName { get; set; }

        //public string Password { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public LoginModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                   // var userServices = new UserServices();
                   // var connectivityStatus = CrossConnectivity.Current.IsConnected;
                    if (true)
                    {

                        //await userServices.loginUsersAsync(_selectedUser);
                    }
                    else
                    {

                        //addSuccess = await App.Database.SaveMember(_selectedUser);
                    }
                    //if (IsSuccess || addSuccess > 0)
                    //{
                    //    if (addSuccess > 0)
                    //    { StatusMessage = "Add Susseccfully Locally"; }
                    //    else
                    //    { StatusMessage = "Add Susseccfully"; }
                    //}
                    //else
                    //{ StatusMessage = "Sorry! Something went wronge."; }
                    IsBusy = false;
                });
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
