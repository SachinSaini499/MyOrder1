using MyOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyOrder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllProductPage : ContentPage
    {
        public AllProductPage()
        {
            InitializeComponent();

            BindingContext = new AllProductModel();
        }
    }
}