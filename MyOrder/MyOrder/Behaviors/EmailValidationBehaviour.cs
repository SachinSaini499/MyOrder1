using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrder.Behaviors
{
   public class EmailValidationBehaviour: Behavior<Entry>
    {


        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var email = e.NewTextValue;
            string emailPatern
                = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


            Entry emailEtnry = sender as Entry;
            if (!Regex.IsMatch(email,emailPatern,RegexOptions.IgnoreCase))
            {
                emailEtnry.TextColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

    }
}
