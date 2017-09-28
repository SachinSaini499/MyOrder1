using MyOrder.Annotations;
using MyOrder.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrder.ViewModel
{
    public class AllProductModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Command AddProductCommand
        {
            get
            {
                return new Command(() =>
                {
                 
                        Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(
                            new AddNewProduct());
                        return;
                   
                   
                });
            }
        }

    }
}
