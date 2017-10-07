using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Java.Lang.Reflect;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;
using MyOrder.Model;
using MyOrder.Services;

namespace MyOrder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AddNewProduct : ContentPage
    {
        private ProductDetail _productDetail = new ProductDetail();
        ProductServices productServices;
        BinaryReader binaryReader;
        byte[] byteImage;
        public bool productFlag = false;
        public bool categoryFlag = false;
        public bool costFlag = false;
        public ProductDetail productDetail
        {
            get { return _productDetail; }
            set
            {
                _productDetail = value;
            }
        }
        public AddNewProduct()
        {
            InitializeComponent();
            BindingContext = productDetail;
            productServices = new Services.ProductServices();
        }
        async private void BtnTakeProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }
                // string pathpic = App.getPicturePath;
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    // Directory = "@" + pathpic,
                    Name = "pic.jpg"
                });

                if (file == null)
                    return;

                // entryImage.Text = file.Path;
                Stream sm = null; Stream sm1 = null;

                MainImage.Source = ImageSource.FromStream(() =>
                {
                    sm1 = file.GetStream();
                    sm = file.GetStream();

                    file.Dispose();
                    return sm1;
                });
                binaryReader = new BinaryReader(sm);
                byteImage = binaryReader.ReadBytes((int)sm.Length);

            }
            catch (Exception ex)
            {
            }

        }
        async private void BtnAddProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                productDetail.ManufacteringDate = ldlDate.Text;
                if (string.IsNullOrEmpty(productDetail.ProductName))
                {
                    productFlag = true;
                }
                if (string.IsNullOrEmpty(productDetail.ProductCategary))
                {
                    categoryFlag = true;
                }
                if (string.IsNullOrEmpty(productDetail.ProductCost))
                {
                    costFlag = true;
                }
                if (!string.IsNullOrEmpty(productDetail.ProductName) && !string.IsNullOrEmpty(productDetail.ProductCategary) && !string.IsNullOrEmpty(productDetail.ProductCost))
                {
                    productFlag = categoryFlag = costFlag = false;
                    await productServices.postUsersAsync(productDetail);
                    await Navigation.PushModalAsync(new AllProductPage());
                }
                else { }
            }
            catch (Exception)
            {
            }
        }
        async private void BtnBrowseProduct_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("OOps", ":( pic photo not supported.", "OK");
                    return;
                }               
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;
                Stream sm = null; Stream sm1 = null;
                MainImage.Source = ImageSource.FromStream(() =>
                {
                    sm1 = file.GetStream();
                    sm = file.GetStream();
                    file.Dispose();
                    return sm1;
                });
                binaryReader = new BinaryReader(sm);
                byteImage = binaryReader.ReadBytes((int)sm.Length);
            }
            catch { }

        }
    }
}