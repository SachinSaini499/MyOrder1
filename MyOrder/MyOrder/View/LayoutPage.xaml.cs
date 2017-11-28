using MyOrder.Interfaces;
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
    public partial class LayoutPage : ContentPage
    {
        public LayoutPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object, string>(this, "UpdateLabel", (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BackgroundServiceLabel.Text = e;

                });
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // DependencyService.Get<IDDTest>().alarmManagerTest();
         
        }
    }
}