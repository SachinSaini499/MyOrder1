using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyOrder.Interfaces;
using MyOrder.Droid;
using Xamarin.Forms;
using Plugin.CurrentActivity;

[assembly:Xamarin.Forms.Dependency(typeof(DDTest))]
namespace MyOrder.Droid
{
   public class DDTest:IDDTest
    {
       public void alarmManagerTest()
        {
            //Activity activity = CrossCurrentActivity.Current.Activity;
            //Toast.MakeText(Forms.Context, "Test", ToastLength.Long).Show();
            //var intent = new Intent(Forms.Context, typeof(PeriodicService));
            //StartService(intent);
        }

       
    }

}