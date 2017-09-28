using MyOrder.Model;
using MyOrder.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Annotations;
using Xamarin.Forms;

namespace MyOrder.ViewModel
{
    class SignUpModel: INotifyPropertyChanged
    {
        List<CustomerDetail> _lstCustomerDetails;
        CustomerServices customerServices;
        private CustomerDetail _customerDetail;
        private bool _isBusy = false;
        public string message;
        public SignUpModel()
        {
            customerServices = new CustomerServices();
            _customerDetail = new CustomerDetail();
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
        public CustomerDetail customerDetail
        {
            get { return _customerDetail; }
            set
            {
                _customerDetail = value;
                OnPropertyChanged();
            }
        }
        public async Task<bool> postData()
        {
          return  await customerServices.postUsersAsync(customerDetail);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command SubmitCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsBusy = true;
                    if (customerDetail.Password == "" || customerDetail.CustomerEmailId == ""|| customerDetail.CustomerName=="")
                    {
                        message = MessageData.EmptyCredential;
                    }
                    else
                    {
                        postData();
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(
                            new LoginPage());
                        return;
                    }
                    IsBusy = false;
                });
            }
        }
    }
}
