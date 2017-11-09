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
using MyOrder.View;
using Xamarin.Forms;

namespace MyOrder.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        List<CustomerDetail> _lstCustomerDetails;
        private CustomerDetail customerDetail;
        private bool _isBusy = false;
        private bool _loginSuccess = false;
        CustomerServices customerServices;
        private string _inValidCreadential;
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginViewModel()
        {           
            customerDetail = new CustomerDetail();
            customerServices = new CustomerServices();
           // getdata();         

        }
        public async void getdata()
        {
            _lstCustomerDetails = await customerServices.GetUsersAsync();
        }        
        public string InValidCreadential
        {
            get
            {
                var validCreadential = _inValidCreadential;
                return validCreadential;
            }
            set { _inValidCreadential = value; }
        }
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
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(
                        new SignUp());
                });
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                   // UserName = "bdfhgdfhgfd";
                   // Password = "877878";
                    if (UserName==""||Password=="")
                    {
                        InValidCreadential = MessageData.EmptyCredential;
                        OnPropertyChanged();
                    }
                    else
                    {
                       // foreach (var item in _lstCustomerDetails)
                        {
                            //if (item.CustomerEmailId == UserName)
                            {
                              //  if (item.Password == Password)
                                {
                                    Application.Current.MainPage.Navigation.PushModalAsync(new AddNewProduct());                             
                                    _loginSuccess = true;
                                    return;
                                }
                            }
                        }
                        if(!_loginSuccess)
                        {
                            InValidCreadential = MessageData.InvalidCredential;
                        }
                    }
                    // // if (lstCustomerDetail == null)
                    //  {
                    //      CustomerDetail customerDetail = new CustomerDetail();
                    //      customerDetail.CustomerName = "Sachin";
                    //      customerDetail.CustomerEmailId = "bdfhgdfhgfd";
                    //      customerDetail.Password = "877878";
                    //      customerServices.postUsersAsync(customerDetail);
                    //  }
                    ////  else
                    //  {
                    //  }
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
