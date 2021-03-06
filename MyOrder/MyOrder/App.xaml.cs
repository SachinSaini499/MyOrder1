﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyOrder.View;
using Xamarin.Forms;

namespace MyOrder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new NavigationPage(new AllProductPage());

            MainPage = new NavigationPage(new LayoutPage())
            {
                BarBackgroundColor = Color.FromHex("#d8a878"),
                BarTextColor = Color.FromHex("#483018")
            };
        }

        protected override void OnStart()
        {
           
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Page p = Application.Current.MainPage;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
