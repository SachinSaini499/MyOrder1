using MyOrder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyOrder.Annotations;
using MyOrder.Services;
using Xamarin.Forms;

namespace MyOrder.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        
        private CustomerDetail _selectedUser = new CustomerDetail();
         private bool _isBusy = false;
         CustomerServices customerServices=new CustomerServices();


        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        //public CustomerDetail SelectedUser
        //{
        //    get { return _selectedUser; }
        //    set
        //    {
        //        _selectedUser = value;
        //        OnPropertyChanged();
        //    }
        //}

        public Command LoginCommand
        {

            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    var customerServices = new CustomerServices();
                    if (true)
                    {
                        Task<List<CustomerDetail>> lstCustomerDetail= customerServices.GetUsersAsync();
                        //await customerServices.loginUsersAsync(_selectedUser);
                    }

                    IsBusy = false;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
