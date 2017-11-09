using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Interfaces;
using MyOrder.View;
using Xamarin.Forms;

namespace MyOrder.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateBack()
        {
           
        }

        public void NavigateToSecondPage()
        {
            var currentPage = GetCurrentPage();
            currentPage.Navigation.PushAsync(new AddNewProduct());
        }

       private Page GetCurrentPage()
       {
           var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
           return currentPage;
       }

    }
}
