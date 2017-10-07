using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrder.Converter
{
   public class ByteToImageConverter: IValueConverter
    {
        ImageSource ShowImage;      

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] byteImage = (byte[])value;
            Stream memoryStream = new MemoryStream(byteImage);

            ShowImage = ImageSource.FromStream(() =>
            {
                return memoryStream;
            });

            return ShowImage;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
