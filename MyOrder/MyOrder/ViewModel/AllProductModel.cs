using MyOrder.Annotations;
using MyOrder.Model;
using MyOrder.Services;
using MyOrder.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrder.ViewModel
{
    public class ProductDetailTemp
    {
        public string ProductName { get; set; }
        public string ProductCategary { get; set; }
        public string ProductCost { get; set; }
        public ImageSource ProductImage { get; set; }
        public string ManufacteringDate { get; set; }
    }
    public class AllProductModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductDetailTemp> items;
        ProductServices productServices = new ProductServices();
        List<ProductDetail> lstProductDetail = new List<ProductDetail>();     
        public ObservableCollection<ProductDetailTemp> lstProductDetail2
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        public AllProductModel()
        {
            lstProductDetail2 = new ObservableCollection<ProductDetailTemp>();
            getData();

        }
        public Command ShowProductCommand
        {
            get
            {
                return new Command(() =>
                {
                    getData();
                });
            }
        }
        public async void getData()
        {
            ProductDetailTemp productDetailTemp = null;
            lstProductDetail = await productServices.GetUsersAsync();
            foreach (var item in lstProductDetail)
            {
                if (item != null)
                {
                    productDetailTemp = new ProductDetailTemp();
                    if (item.ManufacteringDate != null)
                    { productDetailTemp.ManufacteringDate = item.ManufacteringDate; }
                    else
                    { productDetailTemp.ManufacteringDate = "Not Available"; }
                    if (item.ProductCategary != null)
                    {
                        productDetailTemp.ProductCategary = item.ProductCategary;
                    }
                    else { productDetailTemp.ProductCategary = "Not Available"; }
                    if (item.ProductCost != null)
                    {
                        productDetailTemp.ProductCost = item.ProductCost;
                    }
                    else { productDetailTemp.ProductCost = "Not Available"; }
                    if (item.ProductName != null)
                    {
                        productDetailTemp.ProductName = item.ProductName;
                    }
                    else { productDetailTemp.ProductName = "Not Available"; }
                    if (item.ProductImage != null)
                    {
                        productDetailTemp.ProductImage = convertImageFromByte(item.ProductImage);
                    }
                    else { productDetailTemp.ProductImage = "icon.png"; }
                    lstProductDetail2.Add(productDetailTemp);
                }
            }
        }
        public ImageSource convertImageFromByte(byte[] byteImage)
        {
            Stream memoryStream = new MemoryStream(byteImage);
            ImageSource showImage;
            showImage = ImageSource.FromStream(() =>
            {
                return memoryStream;
            });
            return showImage;
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
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
