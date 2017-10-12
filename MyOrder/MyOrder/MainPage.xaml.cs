using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            List<string> myItemsSource = new List<string>();
            myItemsSource.Add("First");
            myItemsSource.Add("Second");
            myItemsSource.Add("Third");
            MianCV.ItemsSource = myItemsSource;
        }
    }
}
